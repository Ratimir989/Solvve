const pricing = {
    "studio": 10,
    "1bed": 15,
    "2bed": 20
}
let model = {
    startdate: "yyyy-mm-dd",
    enddate: "yyyy-mm-dd",
    room: "",
    sum: 0
}


mybinder("startdate", model, 'startdate');
mybinder("enddate", model, 'enddate');
mybinder("room", model, 'room');
mybinder("sum", model, 'sum');

function calc() {
    if (model.startdate && model.enddate && model.room) {
        const days = Math.round((new Date(model.enddate) - new Date(model.startdate)) / (24 * 60 * 60 * 1000));
        if (pricing[model.room]) {
            model.sum = pricing[model.room] * days;
            SUMMA(model.sum)
        }
    }
}

function mybinder(elemId, model, name) {
    let element = document.getElementById(elemId);
    element.addEventListener("change", function(event) {
        model[name] = event.target.value;
        calc();
    });
    watch(element, name);
}

function SUMMA(summa) {
    document.getElementById("sum").value = summa;

}

function watch(object, property) {
    var value = object[property];
    Object.defineProperty(object, property, {
        get: function() {
            return value;
        },
        set: function(newValue) {
            value = newValue;
        }
    });
}