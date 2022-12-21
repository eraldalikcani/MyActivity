using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Activities;

public class AttendeeDto
{
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public bool Following { get; set; }//if the logged in user is following that particular user
    public int FollowersCount { get; set; }
    public int FollowingCount { get; set; }
}
