using EFCore7JsonDemo.Data;
using EFCore7JsonDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore7JsonDemo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonJsonController : ControllerBase {
        private readonly SqlDbContext _context;
        public PersonJsonController(SqlDbContext context) {
            _context = context;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonJsonDbEntity> Get() {
            return _context.PeopleJson.ToList();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public PersonJsonDbEntity? Get(int id) {
            return _context.PeopleJson.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public bool Post([FromBody] PersonJsonDbInput request) {
            if (request.Id != null && request.Id > 0)
                return Put(request);

            var entity = new PersonJsonDbEntity(request.Person);

            if (request.Person.Education != null) {
                entity.Person.Education = new EducationJson {
                    HighSchool = request.Person.Education.HighSchool,
                    GED = request.Person.Education.GED,
                    Associates = request.Person.Education.Associates,
                    Bachelors = request.Person.Education.Bachelors,
                    Masters = request.Person.Education.Masters,
                    Doctorate = request.Person.Education.Doctorate
                };
            }

            //if (request.Person.Addresses != null) {
            //    entity.Person.Addresses = new List<AddressJson>();
            //    foreach (var address in request.Person.Addresses)
            //        entity.Person.Addresses.Add(new Address {
            //            Street = address.Street,
            //            City = address.City,
            //            PostalCode = address.PostalCode,
            //            State = address.State
            //        });
            //}

            _context.PeopleJson.Add(entity);
            _context.SaveChanges();

            return true;
        }

        /**/
        // PUT api/<PersonController>/5
        [HttpPut]
        public bool Put([FromBody] PersonJsonDbInput request) {
            if (request.Id == null)
                return false;

            var entity = _context.PeopleJson.FirstOrDefault(p => p.Id == request.Id);
            if (entity == null)
                return false;

            entity.Person = request.Person;

            //if (entity.Person.Education == null && request.Person.Education != null) {
            //    entity.Person.Education = new EducationJson {
            //        HighSchool = request.Person.Education.HighSchool,
            //        GED = request.Person.Education.GED,
            //        Associates = request.Person.Education.Associates,
            //        Bachelors = request.Person.Education.Bachelors,
            //        Masters = request.Person.Education.Masters,
            //        Doctorate = request.Person.Education.Doctorate
            //    };
            //}
            //else if (entity.Person.Education != null && request.Person.Education == null) {
            //    entity.Person.Education = null;
            //}
            //else if (entity.Person.Education != null && request.Person.Education != null) {
            //    entity.Person.Education.HighSchool = request.Person.Education.HighSchool;
            //    entity.Person.Education.GED = request.Person.Education.GED;
            //    entity.Person.Education.Associates = request.Person.Education.Associates;
            //    entity.Person.Education.Bachelors = request.Person.Education.Bachelors;
            //    entity.Person.Education.Masters = request.Person.Education.Masters;
            //    entity.Person.Education.Doctorate = request.Person.Education.Doctorate;
            //}

            //if (entity.Person.Addresses == null && request.Person.Addresses != null) {
            //    entity.Person.Addresses = new List<AddressJson>();
            //    foreach (var address in request.Person.Addresses)
            //        entity.Person.Addresses.Add(new AddressJson {
            //            Street = address.Street,
            //            City = address.City,
            //            PostalCode = address.PostalCode,
            //            State = address.State
            //        });
            //}
            //else if (entity.Person.Addresses != null && request.Person.Addresses == null) {
            //    entity.Person.Addresses = null;
            //}
            //else if (entity.Person.Addresses != null && request.Person.Addresses != null) {
            //    // update where matched
            //    foreach (var e in entity.Person.Addresses.ToList()) {
            //        var r = request.Person.Addresses.FirstOrDefault(req => req.Id == e.Id);
            //        if (r == null)
            //            continue;
            //        e.Street = r.Street;
            //        e.City = r.City;
            //        e.State = r.State;
            //        e.PostalCode = r.PostalCode;
            //    }
            //    // add from request
            //    var missingFromEntity = request.Person.Addresses.Where(r => entity.Person.Addresses.All(e => e.Id != r.Id)).ToList();
            //    foreach (var ea in missingFromEntity) {
            //        entity.Person.Addresses.Add(new AddressJson {
            //            Street = ea.Street,
            //            City = ea.City,
            //            PostalCode = ea.PostalCode,
            //            State = ea.State
            //        });
            //    }
            //    // remove if not in request
            //    var missingFromRequest = entity.Person.Addresses.Where(e => request.Person.Addresses.All(r => r.Id != e.Id)).ToList();
            //    foreach (var ra in missingFromRequest) {
            //        entity.Person.Addresses.Remove(ra);
            //    }
            //}

            _context.SaveChanges();

            return true;
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id) {
            var entity = _context.PeopleJson.FirstOrDefault(p => p.Id == id);
            if (entity == null)
                return false;

            _context.PeopleJson.Remove(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
