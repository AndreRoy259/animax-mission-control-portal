using AnimaxMissionControlPortal.Domain.Entities;
using AnimaxMissionControlPortal.Domain.Enums;

namespace AnimaxMissionControlPortal.Data.Seed;

public static class AnimaxSeedData
{
    public static readonly DateTime BaseTime = new(2026, 4, 25, 9, 0, 0, DateTimeKind.Utc);

    public static IReadOnlyList<Division> Divisions =>
    [
        new() { Id = 1, Code = "CCCU", Name = "Central Command Coordination Unit", OperationalDomain = "Coordination centrale", Description = "Synchronise les arbitrages inter-division fictifs.", VisualSignal = "cyan" },
        new() { Id = 2, Code = "FAAD", Name = "Field Analytics and Action Division", OperationalDomain = "Analyse terrain", Description = "Transforme les signaux demo en plans d'action.", VisualSignal = "green" },
        new() { Id = 3, Code = "PBRL", Name = "Prototype Bio-Research Lab", OperationalDomain = "Recherche prototype", Description = "Suit les lots experimentaux fictifs.", VisualSignal = "violet" },
        new() { Id = 4, Code = "HECH", Name = "Habitat Engineering and Containment Hub", OperationalDomain = "Infrastructure habitat", Description = "Controle les dependances d'environnement simule.", VisualSignal = "amber" },
        new() { Id = 5, Code = "BOACT", Name = "Behavioral Operations and Care Team", OperationalDomain = "Operations comportementales", Description = "Supervise les protocoles de soin fictifs.", VisualSignal = "rose" },
        new() { Id = 6, Code = "REMS", Name = "Remote Expedition Monitoring Section", OperationalDomain = "Expeditions distantes", Description = "Coordonne les sites de demonstration eloignes.", VisualSignal = "blue" },
        new() { Id = 7, Code = "FMRA", Name = "Finance, Materials and Risk Assembly", OperationalDomain = "Ressources et risques", Description = "Suit les arbitrages de ressources demo.", VisualSignal = "lime" }
    ];

    public static IReadOnlyList<Mission> Missions =>
    [
        Mission(1, "Synchroniser le tableau de crise Animax", 1, MissionStatus.Active, Priority.Critical, ClassificationLevel.Confidential, AlertLevel.Critical, "Mission Operator", "Centraliser les signaux critiques pour la revue quotidienne."),
        Mission(2, "Stabiliser la chaine de ravitaillement nocturne", 7, MissionStatus.Blocked, Priority.High, ClassificationLevel.Internal, AlertLevel.Elevated, "Division Lead", "Lever les dependances fictives de materiel."),
        Mission(3, "Qualifier le protocole habitat Sigma", 4, MissionStatus.Active, Priority.Medium, ClassificationLevel.Classified, AlertLevel.Normal, "HECH Coordinator", "Valider les seuils de confort et de confinement demo."),
        Mission(4, "Analyser les retours de terrain Nord", 2, MissionStatus.Completed, Priority.Low, ClassificationLevel.Internal, AlertLevel.Normal, "FAAD Analyst", "Synthese terminee pour le sprint precedent."),
        Mission(5, "Evaluer le comportement des specimens virtuels", 5, MissionStatus.Draft, Priority.Medium, ClassificationLevel.Confidential, AlertLevel.Elevated, "BOACT Lead", "Preparatifs pour scenario d'observation."),
        Mission(6, "Reviser l'index Blackfile des prototypes", 3, MissionStatus.Active, Priority.Critical, ClassificationLevel.Blackfile, AlertLevel.Elevated, "PBRL Archivist", "Mise a jour demo des priorites de laboratoire."),
        Mission(7, "Recadrer les expeditions du secteur Est", 6, MissionStatus.Blocked, Priority.Critical, ClassificationLevel.Classified, AlertLevel.Critical, "REMS Planner", "Coordination bloquee par fenetre de liaison simulee."),
        Mission(8, "Standardiser les briefings de division", 1, MissionStatus.Active, Priority.Low, ClassificationLevel.Internal, AlertLevel.Normal, "Mission Operator", "Creer un format commun pour le portail."),
        Mission(9, "Valider le budget des modules mobiles", 7, MissionStatus.Archived, Priority.Medium, ClassificationLevel.Confidential, AlertLevel.Normal, "FMRA Controller", "Historique conserve pour demonstration."),
        Mission(10, "Controler les alertes de confinement", 4, MissionStatus.Active, Priority.High, ClassificationLevel.Classified, AlertLevel.Critical, "HECH Coordinator", "Aligner la lecture des alertes avec le dashboard."),
        Mission(11, "Preparer la simulation Executive Review", 1, MissionStatus.Draft, Priority.High, ClassificationLevel.Confidential, AlertLevel.Elevated, "Executive Viewer", "Assembler les cartes critiques pour la demo."),
        Mission(12, "Nettoyer le backlog d'actions FAAD", 2, MissionStatus.Completed, Priority.Low, ClassificationLevel.Internal, AlertLevel.Normal, "FAAD Analyst", "Actions mineures fermees pour garder le jeu lisible.")
    ];

    public static IReadOnlyList<MissionUpdate> MissionUpdates =>
    [
        Update(1, 1, "Signal critique consolide dans le rapport central.", "Mission Operator"),
        Update(2, 1, "Priorite confirmee pour revue executive.", "Executive Viewer"),
        Update(3, 2, "Blocage materiel identifie avec FMRA.", "Division Lead"),
        Update(4, 3, "Premier passage habitat valide.", "HECH Coordinator"),
        Update(5, 4, "Analyse terrain livree aux divisions.", "FAAD Analyst"),
        Update(6, 6, "Index prototype harmonise avec PBRL.", "PBRL Archivist"),
        Update(7, 7, "Fenetre de liaison toujours indisponible.", "REMS Planner"),
        Update(8, 8, "Modele de briefing partage.", "Mission Operator"),
        Update(9, 10, "Alerte critique reproduite en environnement local.", "HECH Coordinator"),
        Update(10, 11, "Narratif de supervision pret pour repetition.", "Executive Viewer")
    ];

    public static IReadOnlyList<RiskBlocker> RiskBlockers =>
    [
        Risk(1, 1, RiskBlockerType.Risk, RiskBlockerStatus.Open, "Confusion possible entre alerte demo et securite reelle.", "Mission Operator"),
        Risk(2, 2, RiskBlockerType.Blocker, RiskBlockerStatus.Open, "Decision de ressource fictive manquante.", "Division Lead"),
        Risk(3, 3, RiskBlockerType.Risk, RiskBlockerStatus.Resolved, "Ancien seuil habitat clarifie.", "HECH Coordinator"),
        Risk(4, 6, RiskBlockerType.Risk, RiskBlockerStatus.Open, "Lecture Blackfile doit rester explicitement non securitaire.", "PBRL Archivist"),
        Risk(5, 7, RiskBlockerType.Blocker, RiskBlockerStatus.Open, "Fenetre de liaison simulee indisponible.", "REMS Planner"),
        Risk(6, 10, RiskBlockerType.Risk, RiskBlockerStatus.Open, "Trop d'alertes critiques peuvent masquer les priorites.", "HECH Coordinator"),
        Risk(7, 11, RiskBlockerType.Risk, RiskBlockerStatus.Resolved, "Narratif executive simplifie.", "Executive Viewer"),
        Risk(8, 5, RiskBlockerType.Blocker, RiskBlockerStatus.Open, "Scenario d'observation en attente de validation.", "BOACT Lead")
    ];

    private static Mission Mission(int id, string title, int divisionId, MissionStatus status, Priority priority, ClassificationLevel classification, AlertLevel alert, string author, string description) => new()
    {
        Id = id,
        Title = title,
        Description = description,
        DivisionId = divisionId,
        Status = status,
        Priority = priority,
        Classification = classification,
        AlertLevel = alert,
        CreatedAt = BaseTime.AddDays(-id),
        UpdatedAt = BaseTime.AddHours(id),
        CreatedBy = author
    };

    private static MissionUpdate Update(int id, int missionId, string content, string author) => new()
    {
        Id = id,
        MissionId = missionId,
        Content = content,
        Author = author,
        CreatedAt = BaseTime.AddHours(id)
    };

    private static RiskBlocker Risk(int id, int missionId, RiskBlockerType type, RiskBlockerStatus status, string description, string author) => new()
    {
        Id = id,
        MissionId = missionId,
        Type = type,
        Status = status,
        Description = description,
        Author = author,
        CreatedAt = BaseTime.AddHours(id * 2),
        ResolvedAt = status == RiskBlockerStatus.Resolved ? BaseTime.AddHours(id * 2 + 1) : null
    };
}
