using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Logic.Repositories;
using GymnasticScores.Data.Entities;

namespace GymnasticScores.Data.Repositories // Match namespace convention from example
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GymnasticsScoresDbContext _context;
        private readonly IMapper _mapper;

        // Constructor Injection
        public CategoryRepository(GymnasticsScoresDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get all Categories - include Rounds as they are part of the Model
        public async Task<List<Category>> All()
        {
            // Option 1: Load entities then map (like EventRepository.All)
            var entities = await _context.Categories
                .Include(c => c.Rounds) // Essential for the Category model
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<Category>>(entities);

            // Option 2: Use ProjectTo for potentially better performance
            // return await _context.Categories
            //     .AsNoTracking()
            //     .ProjectTo<Category>(_mapper.ConfigurationProvider) // AutoMapper handles Includes needed for projection
            //     .ToListAsync();
        }

        // Get single Category by ID - include Rounds
        public async Task<Category> Get(string id)
        {
            var entity = await _context.Categories
                .Include(c => c.Rounds) // Essential for the Category model
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return entity != null ? _mapper.Map<Category>(entity) : null!; // Suppress nullable warning if interface expects non-null
        }

        // Insert or Update Category and its Rounds
        public async Task Upsert(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            var existingCategory = await _context.Categories
                .Include(c => c.Rounds) // Load existing Rounds for comparison/update
                .FirstOrDefaultAsync(e => e.Id == category.Id);

            if (existingCategory != null)
            {
                // Update existing Category
                _mapper.Map(category, existingCategory); // Map properties onto tracked entity
                UpsertRoundsInPlace(category, existingCategory); // Handle child collection changes
            }
            else
            {
                // Insert new Category
                var categoryEntity = _mapper.Map<CategoryEntity>(category);
                // Set default values if needed e.g., categoryEntity.Added = DateTime.UtcNow;
                UpsertRoundsInPlace(category, categoryEntity); // Prepare child collection for insert
                await _context.Categories.AddAsync(categoryEntity); // Add the graph
            }

            await _context.SaveChangesAsync();
        }

        // Helper to manage adding/updating/deleting Rounds within a Category transaction
        private void UpsertRoundsInPlace(Category category, CategoryEntity categoryEntity)
        {
            categoryEntity.Rounds ??= new List<RoundEntity>(); // Ensure collection exists

            var inputRoundIds = category.Rounds.Select(r => r.Id).ToHashSet();
            
            var roundsToRemove = categoryEntity.Rounds.Where(re => !inputRoundIds.Contains(re.Id)).ToList();
            foreach (var roundToRemove in roundsToRemove)
            {
                categoryEntity.Rounds.Remove(roundToRemove);
            }

            foreach (var roundModel in category.Rounds)
            {
                var existingRoundEntity = categoryEntity.Rounds.FirstOrDefault(re => re.Id == roundModel.Id);

                if (existingRoundEntity != null)
                {
                    _mapper.Map(roundModel, existingRoundEntity);
                }
                else
                {
                    var newRoundEntity = _mapper.Map<RoundEntity>(roundModel);
                    categoryEntity.Rounds.Add(newRoundEntity); 
                }
            }
        }
        
        public async Task Delete(string id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);

            if (categoryEntity != null)
            {
                _context.Categories.Remove(categoryEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}