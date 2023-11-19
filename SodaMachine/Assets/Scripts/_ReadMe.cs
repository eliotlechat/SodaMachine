



// Refactorisation: 
// mettre la variable OpenTabSound dans CanScript pour plus de cohérence et appelé la méthode depuis PlayerScript
// Le fallingTriggerScruot pour être dans le Script StackScript.


// Améliorations : 
// Mettre une pop up, Collect item
// Mettre une pop up Collect open can 
// Mettre une pop up Drink
// Mettre en place le NFC 
// ajouter l'anim de la tab et le matériau change
// ouverture de la porte
// Gestion du pavé numérique avec emission 






/// Bugs report : 
// je peux activer le son openTabSound a un moment inapproprié 
// Je reste coincée quand je me colle au distributeur
// Les commentaires du code ne sont pas tjrs en anglais
// Je me fais pousser quand j'active l'animation de la main qui boit.  
// il faut que j'agrandisse le bac de récupération parce que problème de physique.e
// Je peux appuyer une seconde fois mais le moveCans ne se refait pas. voir la méthode


/// Reflexions : 
// activer l'anim play.setTrigger("openingTabEvent")
// dans la méthode PlayOpeningTab() sauf qu'il faut que je reference tab qui est un enfant