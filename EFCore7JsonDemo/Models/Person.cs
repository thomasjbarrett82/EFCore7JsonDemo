namespace EFCore7JsonDemo.Models;

public class Person {
    public Person(string name) {
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Education? Education { get; set; }
    public List<Address>? Addresses { get; set; }
}

public class Education {
    public int Id { get; set; }
    public bool HighSchool { get; set; } = false;
    public bool GED { get; set; } = false;
    public bool Associates { get; set; } = false;
    public bool Bachelors { get; set; } = false;
    public bool Masters { get; set; } = false;
    public bool Doctorate { get; set; } = false;
    public int PersonId { get; set; }
}

public class Address {
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public int PersonId { get; set; }
}

public class PersonInput {
    public int? Id { get; set; }
    public string Name { get; set; }
    public EducationInput? Education { get; set; }
    public List<AddressInput>? Addresses { get; set; }
}

public class EducationInput {
    public int? Id { get; set; }
    public bool HighSchool { get; set; } = false;
    public bool GED { get; set; } = false;
    public bool Associates { get; set; } = false;
    public bool Bachelors { get; set; } = false;
    public bool Masters { get; set; } = false;
    public bool Doctorate { get; set; } = false;
    public int PersonId { get; set; }
}

public class AddressInput {
    public int? Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public int PersonId { get; set; }
}
