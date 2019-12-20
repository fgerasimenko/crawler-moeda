function Conta() {
    if (!(this instanceof Conta)) {
        return new Conta();
    }
};

Conta.ViewModel = null;

Conta.prototype.Init = function Init() {

    Conta.ViewModel = {
        Codigo: ko.observable(""),
        Id: ko.observable(""),
        Saldo: ko.observable("")
    };

    ko.applyBindings(Conta.ViewModel);
};

Conta.prototype.GetConta = function GetTracking() {
    $.ajax({
        url: urlPath + "GetConta",
        type: "GET",
        cache: false,
        async: true,
        beforeSend: function () {
            loading("show");
        },
        dataType: "json",
        success: function (data) {
            loading("hide");

            if (data.status == "success") {
                console.log("Ok");
            }
            else if ((data.status == "failure")) {
                console.log(" Não Ok");
            }
        },
        error: function (error, data) {
            loading("hide");
        }
    });
};

(function () {
    Conta().Init();
})();