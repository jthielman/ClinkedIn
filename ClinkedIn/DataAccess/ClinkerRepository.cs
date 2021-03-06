﻿using ClinkedInPersonal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInPersonal.DataAccess
{
    public class ClinkerRepository
    {
        static List<Clinker> _clinkers = new List<Clinker>
        {
            new Clinker
            {
                Id = 1,
                Name = "Nathan",
                Age = 33,
                LockupReason = "television theft",
                Interests = new List<string>{"Coding", "Stealing TVs"},
                Services = new List<Service>{new Service { Title = "Shiv Maker", Cost = "bar of soap"} }
            }
        };

        public void AddClinkerService(int id, Service service)
        {
            _clinkers[id - 1].Services.Add(service);
            // var clinkerToUpdate = _clinkers.(s => s.Id == id);
        }

        public void AddClinker(Clinker clinker)
        {
            clinker.Id = _clinkers.Max(x => x.Id) + 1;
            _clinkers.Add(clinker);
        }

        public Clinker GetById(int id)
        {
            return _clinkers.FirstOrDefault(c => c.Id == id);
        }

        public List<Clinker> GetClinkersByInterest(string interest)
        {
            /*var matchingClinkers = new List<Clinker>;
            foreach (var clinker in _clinkers)
            {
                if (clinker.Interests.Contains(interest))
                {
                    matchingClinkers.Add(clinker);
                }
            }
            return matchingClinkers;*/

            var matchingClinkers = _clinkers.Where(x => x.Interests.Contains(interest));
            return matchingClinkers.ToList();
        }

        public void AddClinkerFriend(int id, Clinker friendToAdd)
        {
            _clinkers[id - 1].Friends.Add(friendToAdd);
        }

        public void AddClinkerEnemy(int id, Clinker enemyToAdd)
        {
            _clinkers[id - 1].Enemies.Add(enemyToAdd);
        }
    }
}
