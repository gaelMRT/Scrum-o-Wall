# Scrum-o-wall Journal de bord

## 06.04

### Tâches à faire
- Créer le versionning
- Commencer la structure de la documentation
- Redéfinir le cahier des charges
### Liens utiles et idées
Recherche de ressources pour faire du multi touch
https://docs.microsoft.com/fr-fr/dotnet/framework/wpf/advanced/walkthrough-creating-your-first-touch-application?redirectedfrom=MSDN : Permet de changer la taille, tourner et déplacer en utilisant plusieurs doigts
Il faut mettre tout ça dans une classe pour faire des post-it avec et pas que ce soit la fenêtre qui s'en occupe

https://thedigitalprojectmanager.com/fr/meilleurs-outils-scrum/ : Pour l'étude d'opportunité
### Tâches accomplies
- Versioning créé
- Première structure de la documentation effectuée
- Nécessite encore une restructuration de la base de données
## 07.04

### Tâches à faire
- Restructuration de la base de données
- Création de la base de données
- Documentation de la base de données
### Liens utiles et idées
Je pourrais intégrer un Mindmap en créeant une table à chaque mindmap et en utilisant une table pour lier les tables avec le projet. Cependant, l'optimisation risque d'être horrible.
C'est soit ça, soit avoir une méga table qui contiendrais tous les mindmap

### Tâches accomplies 
- Restructuration accomplies
- Base de donnée créée dans un fichier accdb
- Documentation mise à jour pour la base de données
## 08.04

### Tâches à faire
- Création des maquettes 
- Documentation des maquettes
### Liens utiles et idées
J'ai fais les maquettes et la documentation de toutes les maquettes. J'ai même fais les maquettes si jamais je réussissais à faire le mindmap et le gantt (qui s'avèrera plutot être une visualisation des tâches accomplies durant le sprint plutot qu'un vrai gantt)
### Tâches accomplies
- Maquettes créé
- Maquettes documentées sauf gantt et mindmap
## 09.04 (Vacances)
Pendant les vacances, je vais continuer à travailler mais à un rythme moins élevé. J'ai pas mal de trucs à faire chez moi donc je vais en profiter pour effectuer ces tâches ménagères.
### Tâches à faire
- Début de la création du poster
- Création d'un icône
### Liens utiles et idées
J'ai du raccourcir l'écriture du projet afin qu'il rentre dans un icone carré sans pour autant avoir de préjudices sur la lisibilité.
### Tâches accomplies
- Icône créé pour github et pour l'application
- Poster commencé
## 14.04 

### Tâches à faire
- Finir le poster
- Créer le résumé
### Liens utiles et idées
J'ai décidé de mettre des post-it sur le poster afin de représenter la méthode agile ainsi qu'un mindmap comme image d'arrière plan afin de faire penser à la reflexion qu'on doit avoir en permanance lors du développement agile. J'ai voulu garder le poster assez sobre et ne pas rajouter d'informations pour ne pas surcharger l'image.
Je ne sais pas si le résumé est correct. Je devrais demander conseil à Mme. Terrier.
### Tâches accomplies
- Poster
- Premier résumé fini
## 15.04

### Tâches à faire
- Recherche sur les existants
### Liens utiles et idées
- monday.com : [https://monday.com/lp/mb/dpm/scrum/?utm_source=mb&utm_campaign=dpm&utm_medium=scrum%20](https://monday.com/lp/mb/dpm/scrum/?utm_source=mb&utm_campaign=dpm&utm_medium=scrum%20)
- JIRA : [https://www.atlassian.com/software/jira?r=sct](https://www.atlassian.com/software/jira?r=sct)

Spécifique aux écrans interactifs https://www.speechi.net/fr/2019/06/04/comparatif-des-outils-de-visual-management-pour-ecran-interactif/
- Ubikey : [https://www.ubikey.fr/](https://www.ubikey.fr/)

- Trello : [https://trello.com/fr](https://trello.com/fr)
- Kantree : [https://kantree.io/fr/](https://kantree.io/fr/)
- Wrike : [https://www.wrike.com/fr/](https://www.wrike.com/fr/)
### Tâches accomplies
- Trouver plein d'applications pareils

## 20.04

### Tâches à faire
- Analyser les existants
- Créer les classes
### Liens utiles et idées
J'ai réduit pas mal les existant pour garder que les plus pertinents.
J'ai déjà créer les fonctions pour altérer les listes des classes.
### Tâches accomplies
- Existant analyser
- Classes créées

## 21.04

### Tâches à faire
-Faire une vue
### Liens utiles et idées
En fait il faudrait que je fasse le controller avant de faire les vues.
Je vais donc commencer le controller
J'ai eu une erreur "Le fournisseur 'Microsoft.ACE.OLEDB.12.0' n'est pas inscrit sur l'ordinateur local". Je pense que je ne dois pas avoir les drivers.
Après recherches, j'ai trouvé un lien en ligne : 
https://www.microsoft.com/fr-FR/download/details.aspx?id=39358
De plus, Visual Studio à choisit de lancer l'application de préfèrence en 32 bits alors que l'engine de base de données est en 64 bits. J'ai donc du désactivé la préférence aux 32 bits dans les options de Build de l'application 
### Tâches accomplies
- Début de la vue (Manque la création dynamique des projets et de leurs liens respectifs)
- Singlotron de la Database fonctionnelle

## 22.04

### Tâches à faire
- Finir le controlleur pour la vue des projets
- Finir la vue des projets
### Liens utiles et idées
Je galère a trouver un algorithme pour centre verticalement les frame des projets. De plus, je risque de rencontrer un problème si il y a vraiment trop de projets dans la database. Je suis donc parti du haut de la fenêtre et j'ai mis le tout dans un ScrollViewer pour qu'une scrollbar s'affiche automatiquement quand il y a trop de contenu.
Il faut encore que je crée le popup de création et j'aurais fini pour la vue des projets.

### Tâches accomplies
- Fais la création et la récupération des projets
- Première vue créée avec le popup de création