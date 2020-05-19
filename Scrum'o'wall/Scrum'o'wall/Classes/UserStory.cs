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
    public class UserStory : IUsersAssigned
    {
        private int id;
        private int stateId;
        private int projectId;
        private int typeId;
        private int priorityId;
        private List<User> assignedUsers = new List<User>();
        private Type type;
        private Priority priority;
        private State currentState;

        public UserStory(int anId, string aDesc, DateTime? aDateLimit, int aComplexity, int aCompletedComplexity, bool isBlocked, int aProjectId, int aStateId, int aTypeId, int aPriorityId)
        {
            id = anId;
            Description = aDesc;
            DateLimit = aDateLimit;
            ComplexityEstimation = aComplexity;
            CompletedComplexity = aCompletedComplexity;
            Blocked = isBlocked;
            projectId = aProjectId;
            stateId = aStateId;
            typeId = aTypeId;
            priorityId = aPriorityId;
        }

        public int Id { get => id; }
        public int StateId { get => stateId; }
        public int ProjectId { get => projectId; }
        public int TypeId { get => typeId; }
        public int PriorityId { get => priorityId; }
        public string Description { get; set; }
        public State State { get => currentState; set { currentState = value; stateId = value.Id; } }
        public DateTime? DateLimit { get; set; }
        public int CompletedComplexity { get; set; }
        public int ComplexityEstimation { get; set; }
        public bool Blocked { get; set; }
        public Type Type { get => type; set { type = value; typeId = value.Id; } }
        public List<File> Files { get; set; } = new List<File>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<Checklist> Checklists { get; set; } = new List<Checklist>();
        public Priority Priority { get => priority; set { priority = value; priorityId = value.Id; } }


        public void AddUser(User user)
        {
            assignedUsers.Add(user);
        }

        public List<User> GetUsers()
        {
            return assignedUsers;
        }

        public void RemoveUser(User user)
        {
            assignedUsers.Remove(user);
        }
        public override string ToString()
        {
            return Description;
        }
    }
}
