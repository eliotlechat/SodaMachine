



// Refactorisation: 
// mettre la variable OpenTabSound dans CanScript pour plus de coh�rence et appel� la m�thode depuis PlayerScript
// Le fallingTriggerScruot pour �tre dans le Script StackScript.


// Am�liorations : 
// Mettre une pop up, Collect item
// Mettre une pop up Collect open can 
// Mettre une pop up Drink
// Mettre en place le NFC 
// ajouter l'anim de la tab et le mat�riau change
// ouverture de la porte
// Gestion du pav� num�rique avec emission 






/// Bugs report : 
// je peux activer le son openTabSound a un moment inappropri� 
// Je reste coinc�e quand je me colle au distributeur
// Les commentaires du code ne sont pas tjrs en anglais
// Je me fais pousser quand j'active l'animation de la main qui boit.  
// il faut que j'agrandisse le bac de r�cup�ration parce que probl�me de physique.e
// Je peux appuyer une seconde fois mais le moveCans ne se refait pas. voir la m�thode


/// Reflexions : 
// activer l'anim play.setTrigger("openingTabEvent")
// dans la m�thode PlayOpeningTab() sauf qu'il faut que je reference tab qui est un enfant