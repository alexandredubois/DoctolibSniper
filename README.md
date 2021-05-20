# Description
Une app console toute simple qui scrute régulièrement doctolib en recherchant les créneaux dispos autour de votre ville.
Quand un créneau dispo est trouvé, l'app émet un signal sonore et ouvre le navigateur sur la page du centre de vaccination en question.
En théorie cela fonctionne sous Windows, Mac et Linux.

# Bien démarrer
1. Si ce n'est pas déjà fait, installer le SDK dotnet core correspondant à votre système depuis ici : https://dotnet.microsoft.com/download
2. Editez le fichier Program.cs avec l'URL correspondant à votre ville (variable `doctolibSearchUrl`). Si vous souhaitez ignorer les créneaux de certains centres de vaccination, vous pouvez les mentionner dans la variable `centersToIgnore`. Il y a également une variable `centerDepartmentsToIgnore` pour sépcifier des départements entiers dont on souhaite ignorer les disponibilités des centres de vaccination.
3. Depuis un terminal ou une invite de commande dans le répertoire cloné, lancez la commande `dotnet run` et laissez la magie opérer ;) 

# Quelques conseils
Ce n'est certainement pas le bout de code dont je suis le plus fier mais il a rempli son rôle.
A l'heure où j'écris ces lignes, les créneaux partent en quelques secondes, aussi je vous conseille d'avoir créé au préalable votre compte utilisateur doctolib :)
Bonne chance à vous.

