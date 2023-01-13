namespace EFCore7JsonDemo.Models;

public class PersonJson {
    public PersonJson(string name) {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public EducationJson? Education { get; set; }

    //public List<AddressJson>? Addresses { get; set; }
}

public class EducationJson { 
    public bool HighSchool { get; set; } = false;
    public bool GED { get; set; } = false;
    public bool Associates { get; set; } = false;
    public bool Bachelors { get; set; } = false;
    public bool Masters { get; set; } = false;
    public bool Doctorate { get; set; } = false;
}

public class AddressJson {
    public AddressJson() {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
}

public class PersonJsonDbEntity {
    public PersonJsonDbEntity() {
        Person = new PersonJson(string.Empty);
    }

    public PersonJsonDbEntity(PersonJson person) {
        Person = person;
    }

    public int Id { get; set; }
    public PersonJson Person { get; set; }
}

public class PersonJsonDbInput {
    public PersonJsonDbInput(PersonJson person) {
        Person = person;
    }

    public int? Id { get; set; }
    public PersonJson Person { get; set; }
}
