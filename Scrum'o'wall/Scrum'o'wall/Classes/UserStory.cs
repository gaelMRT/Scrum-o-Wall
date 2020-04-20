/*
 * Author   :   Gaël Serge Mariot
 * Project  :   Scrum'o'wall
 * File     :   UserStory.cs
 * Desc.    :   This file contains the structure of the UserStory class   
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum_o_wall.Classes
{
    class UserStory
    {
        private string text;
        private string currentState;
        private float timeEstimation;
        private int complexityEstimation;

        public string Text { get => text; set => text = value; }
        public string CurrentState { get => currentState; set => currentState = value; }
        public float TimeEstimation { get => timeEstimation; set => timeEstimation = value; }
        public int ComplexityEstimation { get => complexityEstimation; set => complexityEstimation = value; }

        public UserStory(string aDesc, float aTime, int aComplexity)
        {
            Text = aDesc;
            TimeEstimation = aTime;
            ComplexityEstimation = aComplexity;
        }
    }
}
