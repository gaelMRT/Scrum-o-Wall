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

## 23.04

### Tâches à faire
- Créer la forme principale des autres vues
- Créer une méthode controller pour avoir toutes les infos des projets
- Mise à jour du planning actuel
### Liens utiles et idées
Il n'existe pas de numeric updown par défaut dans WPF. Mais il existe un package nuget 
qui l'ajoute (Source : 
https://stackoverflow.com/questions/841293/where-is-the-wpf-numeric-updown-control) Je 
sais pas si je vais utilisé cela car il ne permet que peu de choses de par sa licence. Je vais chercher une autre solution.
Finalement je vais juste filtrer les entrées utilisateurs et mettre un textbox. C'est le plus simple à faire sans plugin.
J'aimerais quand même avoir un petit clavier virtuel qui respecterait le multi-point.
### Tâches accomplies
- Planning mis à jour
- Le controlleur récupère toutes les infos au lancement de l'application
- Les vues du sprint et du backlog ne sont pas finies (sans compter le gantt et le mindmap)

## 24.04

### Tâches à faire
- Finir les vues
- Connecter les vues entre elles
### Liens utiles et idées
J'ai pensé à peut-être une protection de projet par mot de passe.
### Tâches accomplies
- Vues finies
- La connection avec la vue du sprint a un problème. Il ne trouve pas le groupbox

## 27.04

### Tâches à faire
- Régler le problème de la vue du sprint
- Faire les méthodes d'ajout
### Liens utiles et idées
Le problème était que je cherchais le nom sans avoir enregistré le nom : https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.registername?view=netcore-3.1 
Je viens de penser au rajout de colonne et je remarque qu'il me manque des vues. Il me faut un popup de création de colonnes et un popup de gestion de colonnes
### Tâches accomplies 
- Problème de la vue du sprint réglé
- Export des methodes d'accès à la DB dans la classe DB
- Modification de l'orthographe de la doc
- Analyse et priorisation des fonctions du trello
## 28.04

### Tâches à faire
- Approfondir l'analyse approfondie de Trello
- Restructurer la documentation
- Modifier la base de données et la documentation pour s'adapter à l'analyse de Trello.
### Liens utiles et idées

### Tâches accomplies
- Analyse sur Trello approfondie
- Documentation restructurée
- Changement du Modèle Conceptuel de Données et documentation des changements
## 29.04

### Tâches à faire 
- Modifier la base de données
- Créer/Modifier les classes
### Liens utiles et idées
Je ne trouvais pas le diagramme de classe mais après une recherche il fallait l'installer par le Visual Studio Installer
### Tâches accomplies
- Base de données modifiée
- Création des classes et modification des existantes
- Création du diagramme de classe
## 30.04

### Tâches à faire 
- Modification des maquettes existantes
- Refaire des maquettes pour les fenêtres manquantes
- Faire un plan de tests
### Liens utiles et idées

### Tâches accomplies
- Modification des maquettes 
- Maquettes pour les fenêtres manquantes
- Début du plan de test 

## 01.05

### Tâches à faire
- Finir le plan de test
- Faire la réunion avec Mme. Terrier
- Faire le visuel des maquettes
### Liens utiles et idées
Pour la gestion des listes il faudra que je reproduise ça en code :

                <Border BorderBrush="Black" BorderThickness="1" Width="408" >
                    <Grid x:Name="list1"  >
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="30*"></ColumnDefinition>
                            <ColumnDefinition Width="67*"></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <TextBlock VerticalAlignment="Top" TextWrapping="Wrap" Margin="10,10,10,0" TextAlignment="Right"></TextBlock>
                        <ListView Grid.Column="1" VerticalAlignment="Top" x:Name="listItems" Margin="10,10,10,10" Height="76">
                            <CheckBox IsChecked="True">asdasd</CheckBox>
                            <CheckBox IsChecked="False">asdasd</CheckBox>
                            <CheckBox >asdasd</CheckBox>
                        </ListView>
                    </Grid>
                </Border>
### Tâches accomplies
- Plan de test des vues
- Réunion avec Mme.Terrier
- Fais la moitié des visuels
## 04.05

### Tâches à faire 
- Finir les visuels
- Créer les constructeurs des vues
- Placer les valeurs dans le visuel
### Liens utiles et idées
Trouvé de quoi faire la ligne pour le burndown chart https://www.c-sharpcorner.com/UploadFile/mahesh/polyline-in-wpf/
### Tâches accomplies
- Finir les visuels
- Fais les vues suivantes ; Burndown Chart, ChecklistCreate, ActivitesMenus, CheckListItemCreate, ChecklistMenu,CommentCreate, CommentsMenu, MindMapCreate, CommentCreate, CommentMenu
## 05.05

### Tâches à faire 
- Faire une partie des vues restantes
### Liens utiles et idées

### Tâches accomplies
- Fini les vues : FileCreate, FileEdit, FileMenu, ProjectEdit, StateCreate, StateMenu, UserCreate, UserEdit, UserStoryCreate
- Il reste UserStoryEdit et UserMenu

## 06.05

### Tâches à faire 
- Faire les vues restantes
- Corriger le poster

### Liens utiles et idées
Afin de pouvoir utiliser le menu des utilisateurs j'ai du créer une interface car plusieurs classes différentes l'utiliseront. J'ai découvert grâce à cela que la version 8.0 de C# permet d'implémenter les propriétés. Cependant, vu que j'utilise la version 7.3, j'ai dû créer des méthodes pour altérer la liste d'utilisateurs.
### Tâches accomplies
- Fini les vues :  UserStoryEdit et UserMenu
- Création d'une interface
- Rajout du langage de programmation sur le poster
## 07.05

### Tâches à faire 
- Refaire la documentation sur les maquettes écrans
- Refaire la documentation des classes
### Liens utiles et idées
Important de citer que j'ai voulu utiliser du déconnecté
Expliquer la stratégie
Expliquer la notice de connection à Access
Pourquoi j'ai fait une classe d'interface, pourquoi j'ai fait ci et ça.
Les challenges du WPF.
Ce qui est lié à l'écran tactile.
### Tâches accomplies
- Documentation sur les maquettes écrans refaite
- Les diagrammes de classes ont été ajoutés et nécessitent une documentation plus poussée
- Correction de bugs empêchant la compilation

## 08.05

### Tâches à faire
- Implémenter les méthodes de la base de données
### Liens utiles et idées
J'ai eu un problème sur la base de données. Il y avait une erreur lors de l'ajout d'un champ pouvant être nul. Après une recherche, j'ai découvert grâce à cette source : https://www.c-sharpcorner.com/article/enter-null-values-for-datetime-column-of-sql-server/ qu'une classe DBNull possèdait une constante pour les valeurs nulles des bases de données.
### Tâches accomplies
- Implémentation des méthodes de la base de données

## 11.05

### Tâches à faire 
- Rajouter la gestion de l'écran tactile.
- Inclure le drag'n'drop sur ProjectMenu
### Liens utiles et idées
J'ai remarqué qu'il me manquait une vue la dernière fois. Il me manque ChecklistItemEdit.

En plus, il faut que je commence à m'intéresser au drag'n'drop en wpf. J'ai trouvé ce post sur stackoverflow qui pourrait m'en apprendre plus : https://stackoverflow.com/questions/11306194/wpf-dragenter-between-two-canvas-not-firing
Je vais essayer de faire un drag and drop sur le menu du projet.

Le post stackoverflow renvoie sur un tutoriel de wpftutorial : http://wpftutorial.net/DragAndDrop.html.


J'ai un problème pour la liaison du sprint avec les user stories "INSERT INTO TUserStoriesSprint (IdUserStory,IdSprint,Order) VALUES (2,3,1);" ne fonctionne pas avec erreur de syntaxe mais "INSERT INTO TUserStoriesSprint VALUES (2,3,1);" fonctionne.

Après avoir cherché beaucoup trop de temps pour que ce soit raisonnable, j'ai trouvé le problème. Le mot order est reservé par SQL pour le "ORDER BY". j'ai donc renommé le nom du champ par "OrderUserStory".
### Tâches accomplies
- Gestion de l'écran tactile accomplies
- Le drag'n'drop a été ajouté sur ProjectMenu 

## 12.05

### Tâches à faire
- Inclure le drag'n'drop sur SprintMenu
- Rendre le drag'n'drop plus évident

### Liens utiles et idées
J'ai effectué le drag'n'drop mais les user controller ne sont pas effacés. Il faudrait que je mette à jour uniquement le bon UserControl ou que je remette à jour correctement tous les elements de la fenêtre.

J'ai choisi la deuxième option et j'ai du refaire totalement la mise à jour de la vue. Cela m'a pris plus de temps que prévu et je n'ai pas le temps de faire ma deuxième activité.

### Tâches accomplies
- Drag'n'drop sur sprint menu effectué

## 13.05

### Tâches à faire
- Faire le résumé
- Faire l'abstract
- Rendre le résumé et l'abstract

### Liens utiles et idées
Ayant un vocabulaire en français plus fourni que mon vocabulaire anglais, j'ai fait d'abord l'anglais puis j'ai traduit de l'anglais au français.

### Tâches accomplies
- Faire le résumé
- Faire l'abstract
- Rendre le résumé et l'abstract

## 14.05

### Tâches à faire
- Faire des tests
- Régler les problèmes
- Créer les fonctionnalités visuels

### Liens utiles et idées
Problèmes reglées : 
- Le wrap du texte dans des textbox multiligne
- Création de fichier (Mauvais nom de table)
- Création de commentaires (DateTime = mot résérvé)
- Création de checklist (Mauvais nom de table)
- Checkbox to ChecklistItem 
- Changement de la taille de la police de base pour plusieurs fenêtres
- Liste de checklistItem non initialisée

Fonctionalités visuels :
- Couleur sur les sprints (Rouge = déjà passé, Bleu = en cours, Gris = à venir)
- Augmentation de la taille des User Stories et des Sprints
- Limiter les charactères

Autres :
- Mise en ordre de la classe DB

Idées :
- Suppression de fichier dans l'user story
- Visuel des sprints sous forme de GANTT

### Tâches accomplies
- Tests effectués
- Problèmes réglés
- Rajout de couleur pour les sprints
- Rajout d'une limitation sur l'interface utilisant
- Augmentation de la hauteur des élèments
- Création de la fenêtre ChecklistItemEdit

## 15.05

### Tâches à faire
- Retoucher le résumé et l'abstract
- Rendre la nouvelle version
- Implémenter la fenêtre ChecklistItemEdit dans le fonctionnement : 
 - Accès
 - Modification après fermeture validée
 
### Liens utiles et idées
 J'ai d'abord commencé à faire le résumé et l'abstract puis j'ai rendu sur moodle. Cependant, l'heure de rendu était mise à minuit alors qu'elle était annoncée à 17h. J'ai donc envoyé un message à M. Garcia.
 
 J'ai implémenter la fenêtre d'edition de la checklistItemEdit. J'en ai profité pour modifier quelques fonctions redondantes d'évènement en acceptant l'interface EventArgs au lieu d'accepter les évènements de type plus particulier.

### Tâches accomplies
- Retoucher le résumé et l'abstract
- Rendre la nouvelle version
- Implémenter la fenêtre ChecklistItemEdit dans le fonctionnement : 
-- Accès
-- Modification après fermeture validée
- Ajout de limitations sur les utilisateurs assignés

## 18.05

### Tâches à faire
- Implémenter l'ajout d'activités
- Refactoriser le code
 
### Liens utiles et idées
 Pour implémenter l'ajout des activités, j'ai pensé qu'il serait mieux que rien ne soit lié à l'interface utilisateur. Cependant, j'ai jugé plus interessant que ce soit le controlleur qui s'occupe d'appeler la création des activités. J'ai donc rajouter dans chaque fonction changeant les User Stories un appel à la fonction rajoutant un enregistrement dans les activités.
 
 Après cela, j'ai refactoriser le code en supprimant les fonction redondantes. J'ai ensuite séparé les fonction d'évènement de chaque vue des autres fonctions plus utiles et j'ai regrouper les fonctions dans le controller par leur but tel que la création, mise à jour ou supression d'enregistrement à la base de données.
 
 J'ai commencé à vouloir faire des tests unitaires. Cependant, pour définir la base de données j'ai dû changé le fonctionnement de la classe DB. Il faut absoluement pouvoir définir une base de données sans interface graphique. C'est pourquoi j'ai créer une propriété qui peut être définie pour ouvrir une base de données sans avoir à utiliser l'interface utilisateur
 
 Demain, je m'occuperais de la création des tests unitaires
 
### Tâches accomplies
- Implémenter l'ajout d'activités
- Refactoriser le code
- Définition des tests unitaires