



// Refactorisation: 
// mettre la variable OpenTabSound dans CanScript pour plus de coh�rence et appel� la m�thode depuis PlayerScript


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


///A voir avec Pierre
// Je n'arrive pas � d�placer le d�clenchement du son openTabSound dans la classe CanScript. 
// Le son ne se d�clence pas car il me dit que l'AudioSource est disable. 
// J'ai v�rifi� d'assigner les deux ref�rences de scripts sur l'inspecteur et aussi v�rifier 
// si l'audiosource se d�sactiver. 
// J'ai aussi niveau forc� l'activation du l'audiosource mais rien n'y fait.

// Le fallingTriggerScript pour �tre dans le Script StackScript.
// Par exemple dans ce cas l� comme le void OnTrigger Enter est dans le fallingTrigger est il plus pertinent de le laisser comme tel ?