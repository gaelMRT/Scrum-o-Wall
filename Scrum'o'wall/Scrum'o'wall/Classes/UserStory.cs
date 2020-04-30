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
using System.Windows.Documents;

namespace Scrum_o_wall.Classes
{
    public class UserStory
    {
        private string text;
        private State currentState;
        private DateTime? dateLimit;
        private int completedComplexity;
        private int complexityEstimation;
        private int id;
        private bool blocked;
        private Priority priority;
        private Type type;
        private List<File> files = new List<File>();
        private List<Comment> comments = new List<Comment>();
        private List<Activity> activities = new List<Activity>();
        private List<Checklist> checklists = new List<Checklist>();
        private List<User> assignedUsers = new List<User>();
        private int stateId;
        private int projectId;
        private int typeId;
        private int priorityId;

        public UserStory(int anId, string aDesc, DateTime? aDateLimit, int aComplexity, int aCompletedComplexity, bool isBlocked, int aProjectId, int aStateId, int aTypeId, int aPriorityId)
        {
            Id = anId;
            Text = aDesc;
            DateLimit = aDateLimit;
            ComplexityEstimation = aComplexity;
            CompletedComplexity = aCompletedComplexity;
            Blocked = isBlocked;
            ProjectId = aProjectId;
            StateId = aStateId;
            TypeId = aTypeId;
            PriorityId = aPriorityId;
        }

        public string Text { get => text; set => text = value; }
        public State CurrentState { get => currentState; set => currentState = value; }
        public DateTime? DateLimit { get => dateLimit; set => dateLimit = value; }
        public int CompletedComplexity { get => completedComplexity; set => completedComplexity = value; }
        public int ComplexityEstimation { get => complexityEstimation; set => complexityEstimation = value; }
        public int Id { get => id; set => id = value; }
        public int StateId { get => stateId; set => stateId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public bool Blocked { get => blocked; set => blocked = value; }
        public Type Type { get => type; set => type = value; }
        public List<File> Files { get => files; set => files = value; }
        public List<Comment> Comments { get => comments; set => comments = value; }
        public List<Activity> Activities { get => activities; set => activities = value; }
        public List<Checklist> Checklists { get => checklists; set => checklists = value; }
        public int TypeId { get => typeId; set => typeId = value; }
        public int PriorityId { get => priorityId; set => priorityId = value; }
        public List<User> AssignedUsers { get => assignedUsers; set => assignedUsers = value; }
        internal Priority Priority { get => priority; set => priority = value; }

        public override string ToString()
        {
            return Text;
        }
    }
}
