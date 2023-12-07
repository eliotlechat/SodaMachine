/*J'ai ma m�thode SpawnInHand() et je cherche � savoir o� le mettre 
 * En gros c'est lorsque la canette se trouve dans le collecteur de boisson
 * Si je clique sur le collecteur de boisson
 * Alors la canette SpawnInHand(), c'est � dire se met en enfant de la main et se place � 0,0,0 dans le transform position, et rotation
 * 
 * Actuellement SpawnInHand() est dans la classe CollectingTrayScript mais c'est pas trop logique. Pour l'instant je l'ai mis l� parce 
 * que c'est dans le OnColliderEnter qu'on peut connaitre l'item qui se trouve dans le collectingTray. 
 * Et en plus la detection du raycasst est dans le script Player.  
 *
 * Ma logique me dirait que ce serait dans la classe Item qu'il y aurait la M�thode SpawnInHand 
*/