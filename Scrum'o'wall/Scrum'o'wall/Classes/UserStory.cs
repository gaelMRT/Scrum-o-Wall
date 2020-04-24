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
    public class UserStory
    {
        private string text;
        private string currentState;
        private float timeEstimation;
        private int complexityEstimation;
        private int id;
        private int stateId;
        private int projectId;

        public string Text { get => text; set => text = value; }
        public string CurrentState { get => currentState; set => currentState = value; }
        public float TimeEstimation { get => timeEstimation; set => timeEstimation = value; }
        public int ComplexityEstimation { get => complexityEstimation; set => complexityEstimation = value; }
        public int Id { get => id; set => id = value; }
        public int StateId { get => stateId; set => stateId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }

        public UserStory(int anId, string aDesc, float aTime, int aComplexity,int aProjectId,int aStateId)
        {
            Id = anId;
            Text = aDesc;
            TimeEstimation = aTime;
            ComplexityEstimation = aComplexity;
            ProjectId = aProjectId;
            StateId = aStateId;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
