var personList = function() {
    var model = this;

    model.persons = ko.observableArray();
    model.list = ko.observableArray();
};

personList.prototype = {
    addPerson: function (person)
    {
        this.persons.push(person);
        this.list.push(person.toString());
    },
};

var person = function(firstName, lastName) {
    var model = this;

    model.firstName = ko.observable();
    model.lastName = ko.observable();
    model.certifications = new Array();; //string array

    model.firstName(firstName);
    model.lastName(lastName);
};

person.prototype = {

    addCertification: function (certifications)
    {
        var self = this;

        self.certifications.push(certifications);
    },

    toString: function ()
    {
        var self = this;

        var result = self.firstName() + " " + self.lastName() + " (" + self.certifications.join() + ")";
        return result;
    }
};
