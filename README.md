 Objectif :
Deux joueurs se connectent, interagissent entre eux avec des emojis et messages, et leur score s’affiche dans un mini leaderboard.

▶️ Lancer le jeu :
Ouvrir la scène LoadingScene.unity.

Entrer un pseudonyme dans le champ prévu.

Cliquer sur "Create Room" ou "Join Room" (deux utilisateurs différents doivent le faire).

Une fois dans la scène de jeu, les joueurs apparaissent.

🕹️ Contrôles :
ZQSD pour se déplacer.

1, 2, 3... pour afficher différents emojis.

Le score s’incrémente à chaque interaction.

Le leaderboard est visible en haut à Droite.

📱 Fonctions implémentées :
Système de nom synchronisé.

Système de Ready synchrone entre les joueurs.

Envoi d’emojis visuels au-dessus des têtes.

Envoi de messages texte.

Mini leaderboard synchronisé.

📝 Notes :
L’expérience multijoueur utilise Photon PUN 2, donc les deux utilisateurs doivent être connectés à Internet.

Aucun serveur dédié n’est requis, tout passe par les services Photon.

🔧 Test Technique – Prototype n°2 : Multijoueur Simple
Objectif :
Créer une scène Unity avec 2 joueurs pouvant interagir ensemble en multijoueur local ou online.
Détails :
Utiliser un framework de votre choix : Photon , Mirror, Unity Netcode


Chaque joueur contrôle un personnage simple


Les joueurs peuvent envoyer une interaction (emoji ou son)


La scène affiche les noms des joueurs


Un bouton "Ready" synchronisé entre les deux


Bonus :
Voice Chat ou Messaging


Mini leaderboard synchronisé
