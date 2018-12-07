using UnityEngine;

public class GameStatus : MonoBehaviour {
     int    intLevel;
     int    intScore;
     string strTitle; 

    public  void incrementScore()
    {
            this.intLevel++;
            //modify to increment the score when the player is playing a new level
            this.intScore += 5;

            if (this.intLevel >= 1 && this.intLevel <= 3)
            {
                this.strTitle.Equals("Trainee");
            }
            else if (this.intLevel >= 4 && this.intLevel <= 6)
            {
            this.strTitle.Equals("Tech");
            }
            else if (this.intLevel >= 7 && this.intLevel <= 9)
            {
            this.strTitle.Equals("Pharm Intern");
            }
            else if (this.intLevel == 10)
            {
            this.strTitle.Equals("Pharmacist");
            }
            else
            {
                return;
            }   
    }    
}
