using AutoMapper;
using GymnasticScores.Logic.Model;
using GymnasticScores.Services.ScoreExpress.Model;

namespace GymnasticScores.Services.ScoreExpress;

public class ExerciseCodeResolver //: IValueResolver<RecreatexDiscipline, Discipline, ExerciseCode>
{
    private static readonly Dictionary<string, ExerciseCode> StringToEnumMap = new ()
    {
        { "acro-exercise-balance", ExerciseCode.AcroExerciseBalance },
        { "acro-exercise-dynamic", ExerciseCode.AcroExerciseDynamic },
        { "acro-exercise-combined", ExerciseCode.AcroExerciseCombined },
        { "acro-exercise-canes", ExerciseCode.AcroExerciseCanes },
        { "acro-exercise-group", ExerciseCode.AcroExerciseGroup },
        { "acro-exercise-sync", ExerciseCode.AcroExerciseSync },
        { "aer-exercise-routine", ExerciseCode.AerExerciseRoutine },
        { "dance-exercise", ExerciseCode.DanceExercise },
        { "demo-exercise", ExerciseCode.DemoExercise },
        { "dmt-exercise-1", ExerciseCode.DmtExercise1 },
        { "dmt-exercise-2", ExerciseCode.DmtExercise2 },
        { "dmt-exercise-3", ExerciseCode.DmtExercise3 },
        { "dmt-exercise-4", ExerciseCode.DmtExercise4 },
        { "mag-exercise-physical", ExerciseCode.MagExercisePhysical },
        { "mag-exercise-floor", ExerciseCode.MagExerciseFloor },
        { "mag-exercise-pommel2", ExerciseCode.MagExercisePommel2 },
        { "mag-exercise-pommel", ExerciseCode.MagExercisePommel },
        { "mag-exercise-mushroom", ExerciseCode.MagExerciseMushroom },
        { "mag-exercise-rings", ExerciseCode.MagExerciseRings },
        { "mag-exercise-vault", ExerciseCode.MagExerciseVault },
        { "mag-exercise-bars", ExerciseCode.MagExerciseBars },
        { "mag-exercise-highbar", ExerciseCode.MagExerciseHighbar },
        { "magt-exercise-physical", ExerciseCode.MagtExercisePhysical },
        { "magt-exercise-artistic", ExerciseCode.MagtExerciseArtistic },
        { "magt-exercise-trampoline", ExerciseCode.MagtExerciseTrampoline },
        { "magt-exercise-floor", ExerciseCode.MagtExerciseFloor },
        { "magt-exercise-pommel", ExerciseCode.MagtExercisePommel },
        { "magt-exercise-rings", ExerciseCode.MagtExerciseRings },
        { "magt-exercise-vault", ExerciseCode.MagtExerciseVault },
        { "magt-exercise-bars", ExerciseCode.MagtExerciseBars },
        { "magt-exercise-highbar", ExerciseCode.MagtExerciseHighbar },
        { "magt-exercise-handstand", ExerciseCode.MagtExerciseHandstand },
        { "recreaag-exercise-vault", ExerciseCode.RecreaagExerciseVault },
        { "recreaag-exercise-bars", ExerciseCode.RecreaagExerciseBars },
        { "recreaag-exercise-beam", ExerciseCode.RecreaagExerciseBeam },
        { "recreaag-exercise-floor", ExerciseCode.RecreaagExerciseFloor },
        { "recreatt-ex-1", ExerciseCode.RecreattEx1 },
        { "recreatt-ex-2", ExerciseCode.RecreattEx2 },
        { "recreatt-ex-3", ExerciseCode.RecreattEx3 },
        { "recreatt-ex-4", ExerciseCode.RecreattEx4 },
        { "recreatt-ex-5", ExerciseCode.RecreattEx5 },
        { "rg-exercise-free", ExerciseCode.RgExerciseFree },
        { "rg-exercise-rope", ExerciseCode.RgExerciseRope },
        { "rg-exercise-hoop", ExerciseCode.RgExerciseHoop },
        { "rg-exercise-ball", ExerciseCode.RgExerciseBall },
        { "rg-exercise-clubs", ExerciseCode.RgExerciseClubs },
        { "rg-exercise-ribbon", ExerciseCode.RgExerciseRibbon },
        { "rg-exercise-group1", ExerciseCode.RgExerciseGroup1 },
        { "rg-exercise-group2", ExerciseCode.RgExerciseGroup2 },
        { "rg-exercise-choice", ExerciseCode.RgExerciseChoice },
        { "rg-exercise-hoop-ball", ExerciseCode.RgExerciseHoopBall },
        { "rg-exercise-hoop-clubs", ExerciseCode.RgExerciseHoopClubs },
        { "rg-exercise-hoop-ribbon", ExerciseCode.RgExerciseHoopRibbon },
        { "rg-exercise-ball-ribbon", ExerciseCode.RgExerciseBallRibbon },
        { "rope-exercise-speed", ExerciseCode.RopeExerciseSpeed },
        { "rope-exercise-endurance", ExerciseCode.RopeExerciseEndurance },
        { "rope-exercise-freestyle-2023", ExerciseCode.RopeExerciseFreestyle2023 },
        { "rope-exercise-freestyle-2022", ExerciseCode.RopeExerciseFreestyle2022 },
        { "rope-exercise-freestyle-2020", ExerciseCode.RopeExerciseFreestyle2020 },
        { "rope-exercise-freestyle", ExerciseCode.RopeExerciseFreestyle },
        { "rope-cd-exercise1", ExerciseCode.RopeCdExercise1 },
        { "rope-cd-exercise2", ExerciseCode.RopeCdExercise2 },
        { "rope-cd-exercise3", ExerciseCode.RopeCdExercise3 },
        { "rope-cd-exercise4", ExerciseCode.RopeCdExercise4 },
        { "rope-cd-exercise5", ExerciseCode.RopeCdExercise5 },
        { "rope-cd-exercise6", ExerciseCode.RopeCdExercise6 },
        { "rope-cd-exercise7", ExerciseCode.RopeCdExercise7 },
        { "rope-cd-exercise8", ExerciseCode.RopeCdExercise8 },
        { "rope-cd-exercise9", ExerciseCode.RopeCdExercise9 },
        { "rope-cd-exercise10", ExerciseCode.RopeCdExercise10 },
        { "rope-demo", ExerciseCode.RopeDemo },
        { "rope-rc-exercise1", ExerciseCode.RopeRcExercise1 },
        { "rope-rc-exercise2", ExerciseCode.RopeRcExercise2 },
        { "rope-rc-exercise3", ExerciseCode.RopeRcExercise3 },
        { "rope-rc-exercise4", ExerciseCode.RopeRcExercise4 },
        { "rope-rc-exercise5", ExerciseCode.RopeRcExercise5 },
        { "rope-rc-exercise6", ExerciseCode.RopeRcExercise6 },
        { "rope-rc-exercise7", ExerciseCode.RopeRcExercise7 },
        { "rope-rc-exercise8", ExerciseCode.RopeRcExercise8 },
        { "rope-rc-exercise9", ExerciseCode.RopeRcExercise9 },
        { "rope-rc-exercise10", ExerciseCode.RopeRcExercise10 },
        { "rope-exercise-sr-speed", ExerciseCode.RopeExerciseSrSpeed },
        { "rope-exercise-du-speed", ExerciseCode.RopeExerciseDuSpeed },
        { "rope-exercise-compulsory", ExerciseCode.RopeExerciseCompulsory },
        { "rope-exercise-dd-speed", ExerciseCode.RopeExerciseDdSpeed },
        { "rope-exercise-dd-sprint", ExerciseCode.RopeExerciseDdSprint },
        { "rope-exercise-sr2-freestyle", ExerciseCode.RopeExerciseSr2Freestyle },
        { "rope-exercise-sr4-freestyle", ExerciseCode.RopeExerciseSr4Freestyle },
        { "rope-exercise-dd3-freestyle", ExerciseCode.RopeExerciseDd3Freestyle },
        { "rope-exercise-dd4-freestyle", ExerciseCode.RopeExerciseDd4Freestyle },
        { "tra-exercise-1", ExerciseCode.TraExercise1 },
        { "tra-exercise-2", ExerciseCode.TraExercise2 },
        { "tra-exercise-3", ExerciseCode.TraExercise3 },
        { "tra-exercise-f", ExerciseCode.TraExerciseF },
        { "trai-exercise-tra1", ExerciseCode.TraiExerciseTra1 },
        { "trai-exercise-tra2", ExerciseCode.TraiExerciseTra2 },
        { "trai-exercise-lm", ExerciseCode.TraiExerciseLm },
        { "trai-exercise-dmt1", ExerciseCode.TraiExerciseDmt1 },
        { "trai-exercise-dmt2", ExerciseCode.TraiExerciseDmt2 },
        { "trai-exercise-dmt3", ExerciseCode.TraiExerciseDmt3 },
        { "tu-exercise-1", ExerciseCode.TuExercise1 },
        { "tu-exercise-2", ExerciseCode.TuExercise2 },
        { "tu-exercise-3", ExerciseCode.TuExercise3 },
        { "tu-exercise-acro", ExerciseCode.TuExerciseAcro },
        { "tu-exercise-acro2", ExerciseCode.TuExerciseAcro2 },
        { "tui-exercise-tu1", ExerciseCode.TuiExerciseTu1 },
        { "tui-exercise-tu2", ExerciseCode.TuiExerciseTu2 },
        { "tui-exercise-flik", ExerciseCode.TuiExerciseFlik },
        { "tui-exercise-tum", ExerciseCode.TuiExerciseTum },
        { "tui-exercise-tum2", ExerciseCode.TuiExerciseTum2 },
        { "tui-exercise-lm", ExerciseCode.TuiExerciseLm },
        { "tui-exercise-tra", ExerciseCode.TuiExerciseTra },
        { "wag-exercise-vault", ExerciseCode.WagExerciseVault },
        { "wag-exercise-bars", ExerciseCode.WagExerciseBars },
        { "wag-exercise-beam", ExerciseCode.WagExerciseBeam },
        { "wag-exercise-floor", ExerciseCode.WagExerciseFloor },
        { "discipline-rg", ExerciseCode.DisciplineRgGenaral }
    };

    
}