using EFCore7JsonDemo.Data;
using EFCore7JsonDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore7Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly SqlDbContext _context;
        public PersonController(SqlDbContext context) {
            _context = context;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get() {
            return _context.People.ToList();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person? Get(int id) {
            return _context.People.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public bool Post([FromBody] PersonInput request) {
            if (request.Id != null && request.Id > 0)
                return Put(request);

            var entity = new Person(request.Name);
            if (request.Education != null) {
                entity.Education = new Education {
                    HighSchool = request.Education.HighSchool,
                    GED = request.Education.GED,
                    Associates = request.Education.Associates,
                    Bachelors = request.Education.Bachelors,
                    Masters = request.Education.Masters,
                    Doctorate = request.Education.Doctorate
                };
            }
            if (request.Addresses != null) {
                entity.Addresses = new List<Address>();
                foreach (var address in request.Addresses)
                    entity.Addresses.Add(new Address { 
                        Street = address.Street,
                        City = address.City,
                        PostalCode = address.PostalCode,
                        State = address.State
                    });
            }

            _context.People.Add(entity);
            _context.SaveChanges();

            return true;
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public bool Put([FromBody] PersonInput request) {
            if (request.Id == null)
                return false;

            var entity = _context.People.FirstOrDefault(p => p.Id == request.Id);
            if (entity == null)
                return false;

            entity.Name = request.Name;

            if (entity.Education == null && request.Education != null) {
                entity.Education = new Education {
                    HighSchool = request.Education.HighSchool,
                    GED = request.Education.GED,
                    Associates = request.Education.Associates,
                    Bachelors = request.Education.Bachelors,
                    Masters = request.Education.Masters,
                    Doctorate = request.Education.Doctorate
                };
            }
            else if (entity.Education != null && request.Education == null) {
                entity.Education = null;
            }
            else if (entity.Education != null && request.Education != null) {
                entity.Education.HighSchool = request.Education.HighSchool;
                entity.Education.GED = request.Education.GED;
                entity.Education.Associates = request.Education.Associates;
                entity.Education.Bachelors = request.Education.Bachelors;
                entity.Education.Masters = request.Education.Masters;
                entity.Education.Doctorate = request.Education.Doctorate;
            }

            if (entity.Addresses == null && request.Addresses != null) {
                entity.Addresses = new List<Address>();
                foreach (var address in request.Addresses)
                    entity.Addresses.Add(new Address {
                        Street = address.Street,
                        City = address.City,
                        PostalCode = address.PostalCode,
                        State = address.State
                    });
            }
            else if (entity.Addresses != null && request.Addresses == null) {
                entity.Addresses = null;
            }
            else if (entity.Addresses != null && request.Addresses != null) {
                // update where matched
                foreach (var e in entity.Addresses.ToList()) {
                    var r = request.Addresses.FirstOrDefault(req => req.Id == e.Id);
                    if (r == null)
                        continue;

                    e.Street= r.Street;
                    e.City= r.City;
                    e.State= r.State;
                    e.PostalCode= r.PostalCode;
                }

                // add from request
                var missingFromEntity = request.Addresses.Where(r => entity.Addresses.All(e => e.Id != r.Id)).ToList();
                foreach (var ea in missingFromEntity) {
                    entity.Addresses.Add(new Address {
                        Street = ea.Street,
                        City = ea.City,
                        PostalCode = ea.PostalCode,
                        State = ea.State
                    });
                }

                // remove if not in request
                var missingFromRequest = entity.Addresses.Where(e => request.Addresses.All(r => r.Id != e.Id)).ToList();
                foreach (var ra in missingFromRequest) {
                    entity.Addresses.Remove(ra);
                }
            }

            _context.SaveChanges();

            return true;
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id) {
            var entity = _context.People.FirstOrDefault(p => p.Id == id);
            if (entity == null)
                return false;

            _context.People.Remove(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
