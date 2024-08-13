/* 
 
Priorité : 



* Corriger les BUGS
* Je peux tjrs interagir avec les boutons alors que j'ai un objet à la main. Est ce 
que c'est pas une erreur de renommer itemInHanScript. j'ai l'impressiosn que ca fait brouillon

 

# faut tester la condition itemIsInHand dans itemScript
# itemIsInHandScript



UPDATES :

_ Comprendre les listes pour les boissons et gérer les différents montants . Le violet sera le plus cher
_ bouteilles d'eau, paquet de chips, 
_ Commenter au départ

BUGS : 


* Quand j'ai un objet à la main, je peux interagir avec la Machine.
* Bug lorsqu'on selectionne une boisson +66
 
Animer l'opercule inferieur 

Dans le script 

*/

/* DESIGN :

* Réduire les plateaux pour plus d'espaces
* Agrandir la hauteur des étagères 
* Repenser le distributeur, il y a un problème déjà je pense qu'il faut agrandir l'espacement
* et mettre des colliders sur les côtés. DIMINUER LES TABLETTES SURTOUT
* Créer des bouteilles d'eau
* La canette n'a pas de hole
* Les canettes ont tous la meme textures.
* La carte n'a pas de textures
* il n'y a pas d'étiquettes de numéro sur clavier
*/

// Je pense qu'avant je dois comprendre les unity events et les accesseurs. les design patterns ("singletons").
/*
 NOTIONS APPRISES : 
* Les méthodes et paramètres
 * La différence entre paramètre et arguments. 
* référencer un objet 
* Instancier un objet. 
* Les TMP
* 

*/

/*
 * Donc si je résume : 
 * On veut éviter le fait de pouvoir toucher le numpad lorsque l'on a une canette dans la main
DOnc pour ca c'est dans le script Raycast de la 47 si le buttonScript != null et que le item n'est pas la main. 
donc la variable c'est itemIsInHand dans la classe itemScript.
Du coup je vais sur itemScript, la variable itemIsInHand est public et est false par défaut. 
Et je vois qu'il n'y a pas de méthode dans le script itemScript pour bouger itemIsInHand en vrai.
Mais c'est dans le script PlayerScript. 
Sauf que dans PlayerScript, c'est le bordel
 *
 */