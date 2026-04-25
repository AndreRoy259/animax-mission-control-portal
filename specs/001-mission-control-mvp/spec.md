# Feature Specification: Animax Mission Control Portal MVP

**Feature Branch**: `001-mission-control-mvp`  
**Created**: 2026-04-25  
**Status**: Draft  
**Input**: User description: "MVP fonctionnel de Animax Mission Control Portal, application web interne fictive pour centraliser, prioriser et suivre des missions inter-divisions dans un univers corporate cyberpunk/classified."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Creer et assigner une mission (Priority: P1)

En tant que Mission Operator, je peux creer une mission avec les informations obligatoires et l'assigner a une division fictive afin que le travail inter-divisions soit visible, priorise et suivi depuis un point central.

**Why this priority**: La creation et l'assignation d'une mission constituent le coeur du MVP. Sans cette capacite, le portail ne peut pas demontrer la centralisation operationnelle.

**Independent Test**: Le scenario peut etre teste en selectionnant le persona Mission Operator, en creant une mission complete, puis en verifiant qu'elle apparait dans la liste, dans sa fiche detaillee et dans les indicateurs du dashboard lorsque ses attributs le justifient.

**Acceptance Scenarios**:

1. **Given** le portail contient des divisions seedeees, **When** le Mission Operator cree une mission avec titre, division, statut, priorite, classification et alert level, **Then** la mission est enregistree et visible dans la liste des missions.
2. **Given** le Mission Operator cree une mission sans champ obligatoire, **When** il tente de valider le formulaire, **Then** la mission n'est pas creee et les champs manquants sont clairement indiques.
3. **Given** une mission est creee avec la priorite Critical ou l'alert level Critical, **When** le dashboard est consulte, **Then** cette mission est mise en evidence comme mission critique.

---

### User Story 2 - Piloter une mission divisionnelle (Priority: P2)

En tant que Division Lead, je peux mettre a jour le statut et la priorite d'une mission, ajouter des updates et declarer des risques ou blocages afin de rendre l'etat operationnel de ma division visible.

**Why this priority**: Le MVP doit demontrer le suivi vivant des missions, pas seulement leur inventaire. Les updates et blocages alimentent directement les indicateurs utiles au cockpit.

**Independent Test**: Le scenario peut etre teste en selectionnant le persona Division Lead, en ouvrant une mission existante, en modifiant son statut ou sa priorite, puis en ajoutant une update et un blocker Open.

**Acceptance Scenarios**:

1. **Given** une mission Active existe, **When** le Division Lead change son statut en Blocked, **Then** la fiche mission, la liste et le cockpit affichent ce nouveau statut.
2. **Given** une mission existe, **When** le Division Lead ajoute une update datable et lisible, **Then** l'update apparait dans l'historique de la fiche mission.
3. **Given** une mission existe, **When** le Division Lead ajoute un RiskBlocker de type Blocker avec le statut Open, **Then** le blocage apparait sur la fiche mission et compte dans les indicateurs de blocages ouverts.
4. **Given** un RiskBlocker existe avec le statut Resolved, **When** le dashboard calcule les indicateurs, **Then** ce risque ou blocage ne compte pas dans les indicateurs ouverts.

---

### User Story 3 - Superviser les missions critiques (Priority: P3)

En tant qu'Executive Viewer, je peux consulter les indicateurs globaux, identifier les missions critiques ou bloquees et ouvrir la fiche d'une mission critique afin d'evaluer rapidement les priorites executive.

**Why this priority**: Le persona executive valide la valeur demo du portail: comprehension rapide, priorisation et acces aux dossiers importants sans action d'edition necessaire.

**Independent Test**: Le scenario peut etre teste en selectionnant le persona Executive Viewer, en consultant le dashboard, puis en ouvrant depuis les zones critiques une mission marquee Critical ou Blocked.

**Acceptance Scenarios**:

1. **Given** des missions seedeees existent avec plusieurs statuts, priorites et alert levels, **When** l'Executive Viewer consulte le dashboard, **Then** il voit les indicateurs globaux de volume, missions critiques, missions bloquees et risques/blocages ouverts.
2. **Given** au moins une mission Critical existe, **When** l'Executive Viewer ouvre sa fiche, **Then** il voit les details principaux, les updates et les risques/blocages associes.
3. **Given** le persona Executive Viewer est actif, **When** il navigue dans le portail, **Then** l'experience peut etre adaptee a la demo sans appliquer de permissions reelles.

---

### User Story 4 - Explorer et filtrer le portefeuille de missions (Priority: P4)

En tant qu'utilisateur demo, je peux lister et filtrer les missions par statut, priorite, division, classification ou alert level afin de retrouver rapidement les dossiers pertinents.

**Why this priority**: La liste filtree relie le cockpit aux fiches mission et rend le MVP utilisable lorsque les donnees seedeees augmentent.

**Independent Test**: Le scenario peut etre teste en appliquant chaque filtre sur un jeu de donnees seedeees et en verifiant que les resultats correspondent aux criteres choisis.

**Acceptance Scenarios**:

1. **Given** plusieurs missions existent, **When** l'utilisateur filtre sur le statut Blocked, **Then** seules les missions bloquees sont affichees.
2. **Given** plusieurs divisions existent, **When** l'utilisateur filtre sur CCCU, FAAD, PBRL, HECH, BOACT, REMS ou FMRA, **Then** seules les missions de la division choisie sont affichees.
3. **Given** aucun resultat ne correspond aux filtres, **When** la liste est affichee, **Then** un etat vide clair indique qu'aucune mission ne correspond.

---

### Key Journey

Dashboard -> Mission List -> Create Mission -> Mission Detail -> Add Update / Add Blocker -> Dashboard Refresh.

### Edge Cases

- Creation d'une mission avec un titre vide ou compose uniquement d'espaces: la validation bloque la creation.
- Creation ou edition d'une mission sans division: la validation bloque la sauvegarde.
- Mission Critical mais non Blocked: elle est mise en evidence comme critique sans etre comptabilisee comme bloquee.
- Mission Blocked avec priorite Low, Medium ou High: elle apparait tout de meme dans le cockpit des missions bloquees.
- RiskBlocker Resolved: il reste consultable dans la fiche mission mais ne compte pas dans les indicateurs ouverts.
- Jeu de donnees sans mission Critical ou Blocked: le dashboard reste fonctionnel et affiche des etats vides explicites.
- Changement de persona demo: l'interface reflete le persona choisi sans masquer ou verrouiller les actions par permission reelle.
- Assets visuels indisponibles: le portail reste utilisable et conserve une presentation coherente.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: Le systeme MUST afficher un dashboard global fonctionnel avec indicateurs de missions totales, missions critiques, missions bloquees et risques/blocages ouverts.
- **FR-002**: Le systeme MUST mettre en evidence les missions dont la priorite est Critical ou dont l'alert level est Critical.
- **FR-003**: Le systeme MUST afficher les missions Blocked dans une zone cockpit ou un regroupement explicitement visible.
- **FR-004**: Le systeme MUST fournir une liste des missions avec filtres par statut, priorite, division, classification et alert level.
- **FR-005**: Le systeme MUST permettre de creer une mission avec au minimum un titre, une division, un statut, une priorite, une classification et un alert level.
- **FR-006**: Le systeme MUST refuser la creation ou la sauvegarde d'une mission lorsque titre, division, statut, priorite, classification ou alert level est manquant.
- **FR-007**: Le systeme MUST permettre d'assigner une mission a une division fictive seedee.
- **FR-008**: Le systeme MUST permettre de modifier le statut d'une mission parmi Draft, Active, Blocked, Completed et Archived.
- **FR-009**: Le systeme MUST permettre de modifier la priorite d'une mission parmi Low, Medium, High et Critical.
- **FR-010**: Le systeme MUST permettre de consulter une fiche mission contenant les attributs principaux, la division assignee, les updates et les risques/blocages.
- **FR-011**: Le systeme MUST permettre d'ajouter une MissionUpdate a une mission avec un contenu textuel, un auteur demo et un horodatage lisible.
- **FR-012**: Le systeme MUST permettre d'ajouter un RiskBlocker a une mission avec un type Risk ou Blocker, un statut Open ou Resolved, une description et un auteur demo.
- **FR-013**: Le systeme MUST compter uniquement les RiskBlocker au statut Open dans les indicateurs de risques et blocages ouverts.
- **FR-014**: Le systeme MUST fournir un referentiel leger des divisions avec leur nom, code, domaine operationnel fictif et signal visuel utilisable dans l'interface.
- **FR-015**: Le systeme MUST inclure des donnees seedeees suffisantes pour demontrer les missions critiques, bloquees, actives, completees, les updates et les risques/blocages.
- **FR-016**: Le systeme MUST inclure des divisions fictives seedeees telles que CCCU, FAAD, PBRL, HECH, BOACT, REMS et FMRA.
- **FR-017**: Le systeme MUST fournir un Demo Persona Switcher avec Mission Operator, Division Lead et Executive Viewer.
- **FR-018**: Le systeme MUST utiliser les personas pour influencer le contexte de demo, les libelles, les accents visuels ou les exemples d'auteur, sans appliquer de permissions reelles.
- **FR-019**: Le systeme MUST indiquer que la classification est informative et ne constitue pas une securite, un controle d'acces ou une protection de donnees.
- **FR-020**: Le systeme MUST fonctionner localement avec des donnees purement fictives, sans dependance a un environnement reel.
- **FR-021**: Le systeme MUST presenter une UI lisible, moderne, coherente et demo-ready dans une vision dark mode de type cyberpunk command center et classified dossier.
- **FR-022**: Le systeme MUST respecter les exclusions MVP: pas d'authentification reelle, pas de RBAC reel, pas d'integrations externes, pas de notifications reelles, pas de workflow d'approbation avance, pas de temps reel, pas de pieces jointes, pas de multi-tenant et pas de recherche avancee.
- **FR-023**: Le systeme MUST conserver son fonctionnement principal meme si les assets visuels non essentiels sont absents ou remplaces.

### Key Entities *(include if feature involves data)*

- **Division**: Division fictive disponible dans le referentiel leger. Attributs principaux: code, nom, domaine operationnel fictif, description courte, couleur ou signal visuel. Une division peut etre assignee a plusieurs missions.
- **Mission**: Dossier de travail inter-divisions. Attributs principaux: titre, description, division assignee, statut, priorite, classification, alert level, dates de creation et de mise a jour, auteur demo. Une mission contient des updates et des risques/blocages.
- **MissionUpdate**: Note d'avancement associee a une mission. Attributs principaux: mission associee, contenu, auteur demo, date de creation.
- **RiskBlocker**: Risque ou blocage associe a une mission. Attributs principaux: mission associee, type Risk ou Blocker, statut Open ou Resolved, description, auteur demo, date de creation ou de resolution.
- **DemoPersona**: Persona de demonstration selectionnable. Attributs principaux: nom, role narratif, division ou contexte associe optionnel, accent UI optionnel. Le persona n'est pas une identite authentifiee.

### Reference Values

- **MissionStatus**: Draft, Active, Blocked, Completed, Archived
- **Priority**: Low, Medium, High, Critical
- **ClassificationLevel**: Internal, Confidential, Classified, Blackfile
- **AlertLevel**: Normal, Elevated, Critical
- **RiskBlockerStatus**: Open, Resolved
- **RiskBlockerType**: Risk, Blocker
- **DemoPersona**: Mission Operator, Division Lead, Executive Viewer

### Demo-Safe Criteria

- Les donnees affichees MUST etre purement fictives.
- Le MVP MUST ne contenir aucune donnee sensible, aucun secret et aucun identifiant d'environnement reel.
- L'authentification MUST etre simulee via Demo Persona Switcher.
- Le MVP MUST ne dependre d'aucun service externe, tenant reel, integration d'entreprise ou notification reelle.
- Les assets visuels MUST etre non critiques au fonctionnement: leur absence ne doit pas empecher les parcours principaux.

### MVP Exclusions

- Pas d'authentification reelle.
- Pas de RBAC reel.
- Pas d'integrations externes.
- Pas de notifications reelles.
- Pas de workflow d'approbation avance.
- Pas de temps reel.
- Pas de pieces jointes.
- Pas de multi-tenant.
- Pas de recherche avancee.

### UX/UI Vision

- Le portail doit exprimer un dark mode lisible et coherent.
- L'ambiance attendue est cyberpunk command center + classified dossier, sans compromettre la comprehension operationnelle.
- Les ecrans doivent etre modernes, demo-ready et adaptes a une application interne de suivi.
- Les design tokens Animax doivent guider les couleurs, contrastes, espacements, niveaux d'alerte et signaux de classification.
- Les composants d'interface doivent etre reutilisables et coherents entre dashboard, liste, formulaire, fiche mission et referentiel divisions.
- La vision fournie pour les phases de realisation mentionne Tailwind CSS et des composants Razor reutilisables comme contraintes de presentation du projet.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Un utilisateur demo peut parcourir Dashboard -> Mission List -> Create Mission -> Mission Detail -> Add Update / Add Blocker -> Dashboard Refresh en moins de 5 minutes avec les donnees seedeees.
- **SC-002**: 100% des missions creees avec les champs obligatoires valides apparaissent dans la liste et dans leur fiche detaillee sans rechargement manuel de donnees par l'utilisateur.
- **SC-003**: 100% des missions Critical ou avec alert level Critical sont visuellement identifiables depuis le dashboard ou la liste.
- **SC-004**: 100% des missions Blocked sont visibles dans le cockpit ou regroupement equivalent des missions bloquees.
- **SC-005**: 100% des RiskBlocker Open sont inclus dans les indicateurs ouverts, et 0 RiskBlocker Resolved n'est comptabilise comme ouvert.
- **SC-006**: Les trois personas demo peuvent etre selectionnes et leur selection est visible dans l'interface en moins de 10 secondes.
- **SC-007**: Au moins 7 divisions fictives seedeees, incluant CCCU, FAAD, PBRL, HECH, BOACT, REMS et FMRA, sont consultables dans le referentiel.
- **SC-008**: Lors d'une revue demo, un evaluateur peut identifier en moins de 30 secondes le nombre de missions critiques, de missions bloquees et de risques/blocages ouverts.
- **SC-009**: Les principaux parcours restent utilisables localement sans connexion a un service externe ou environnement reel.
- **SC-010**: Au moins 90% des libelles et etats importants sont comprehensibles sans explication orale pour un public metier francophone ou anglophone familier des outils internes.

## Assumptions

- Les utilisateurs du MVP sont des personas de demo, pas des comptes applicatifs.
- Le portail est destine a une demonstration locale ou interne fictive, avec persistance suffisante pour les parcours MVP.
- Les donnees seedeees couvrent plusieurs statuts, priorites, classifications, alert levels, divisions, updates et risques/blocages.
- La classification sert a l'ambiance et au tri visuel; elle ne protege aucune donnee et ne limite aucune action.
- Les personas peuvent modifier le contexte narratif, les accents visuels et les auteurs par defaut, mais ne limitent pas l'acces aux actions.
- Le referentiel divisions est volontairement leger et ne vise pas une gestion administrative complete.
- Les filtres de la liste sont des filtres simples; la recherche avancee, le tri complexe et les requetes multi-criteres sophistiquees sont hors MVP.
- Les mentions Tailwind CSS et composants Razor sont des contraintes de presentation transmises par le brief pour la suite du projet; la valeur produit reste definie par les parcours et resultats utilisateur.
