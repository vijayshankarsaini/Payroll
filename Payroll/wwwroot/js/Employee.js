var tbl;
$(document).ready(function () {
    $(function () {
        $('.datepicker').datetimepicker({
            format: 'DD-MMM-YYYY'
        });
    });
    $("#btnAddNew").click(function () {
        $("#myModal").modal('toggle');
        Reset();
        EnableAll();
    });
    loadData();
});

function loadData() {
    tbl = $('.DataTable').DataTable();
    $.ajax({
        url: "Employee/GetList",
        type: "GET",
        datatype: "JSON",
        success: function (data) {
            var sr = 1;
            tbl.clear().draw();
            $.each(data, function (key, item) {
                tbl.row.add([
                    sr,
                    item.name,
                    item.dateOfBirth,
                    item.tin,
                    item.employeeTypeName,
                    "<i title='View' class='pointer text-success' onclick='GetData(" + item.id + ",0)'><span class='glyphicon glyphicon-eye-open'></span></i>&nbsp;&nbsp;&nbsp;" +
                    "<i title='Edit' class='pointer text-primary' onclick='GetData(" + item.id + ",1)'><span class='glyphicon glyphicon-edit'></span></i>&nbsp;&nbsp;&nbsp;" +
                    "<i title='Delete' class='pointer text-danger' onclick='GetData(" + item.id + ",2)'><span class='glyphicon glyphicon-trash'></span></i>"
                ]).draw(false);
                sr = sr + 1;
            });
        },
        error: function (error) {
            ErrorMsg(error);
        }
    });
}

function Action(_mod) {
    if (!$('#form1').valid()) return false;
    else {
        var Obj = {
            Id: $('#Id').val().trim(),
            Name: $('#Name').val().toUpperCase().trim(),
            DateOfBirth: $('#DateOfBirth').val().trim(),
            TIN: $('#TIN').val().toUpperCase().trim(),
            EmployeeType: $('#ddlEmployeeType').val(),
            Days: $('#Days').val()
        };
        $.ajax({
            url: "Employee/Action",
            type: "POST",
            datatype: "JSON",
            data: { str: JSON.stringify(Obj), mod: _mod },
            success: function (data) {
                if (data.split('|')[0] === "0") {
                    $('#myModal').modal('toggle');
                    alert(data.split('|')[1]);
                    loadData();
                }
                else if (data.split('|')[0] === "2") {
                    $("#lblSalaryInfo").text("Salary = " + data.split('|')[1]);
                }
                else {
                    alert(data.split('|')[1]);
                }
            },
            error: function (error) {
                alert(error);
            }
        });
    }
}

function GetData(_Id, _mod) {
    $('#myModal').modal('toggle');
    $.ajax({
        url: "Employee/GetData",
        type: "GET",
        datatype: "JSON",
        data: { id: _Id},
        success: function (data) {
            $('#Id').val(data.id);
            $('#Name').val(data.name);
            $('#DateOfBirth').val(data.dateOfBirth);
            $('#TIN').val(data.tin);
            $('#ddlEmployeeType').val(data.employeeType).change();
            
            //View
            if (_mod === 0) {
                $('#btnAdd').attr('style', 'display:none');
                $('#btnUpdate').attr('style', 'display:none');
                $('#btnDelete').attr('style', 'display:none');
                $('#btnSalary').removeAttr('style');
                $('#title').attr('class', 'glyphicon glyphicon-eye-open');
                $("#divSalary").attr('style', 'display:block');
                DisableAll();
            }
            //Edit
            if (_mod === 1) {
                $('#btnAdd').attr('style', 'display:none');
                $('#btnUpdate').removeAttr('style');
                $('#btnDelete').attr('style', 'display:none');
                $('#btnSalary').attr('style', 'display:none');
                $('#title').attr('class', 'glyphicon glyphicon-edit');
                $("#divSalary").attr('style', 'display:none');
                EnableAll();
            }
            //Delete
            if (_mod === 2) {
                $('#btnAdd').attr('style', 'display:none');
                $('#btnUpdate').attr('style', 'display:none');
                $('#btnDelete').removeAttr('style');
                $('#btnSalary').attr('style', 'display:none');
                $('#title').attr('class', 'glyphicon glyphicon-trash');
                $("#divSalary").attr('style', 'display:none');
                DisableAll();
            }
            Validate();
        },
        error: function (error) {
            alert(error);
        }
    });
}

function Reset() {
    $('#Name').val('');
    $('#DateOfBirth').val('');
    $('#TIN').val('');
    $('#btnAdd').removeAttr('style');
    $('#btnUpdate').attr('style', 'display:none');
    $('#btnDelete').attr('style', 'display:none');
    $('#title').attr('class', 'glyphicon glyphicon-plus-sign');
    $("#lblSalaryInfo").text('');
    $("#divSalary").attr('style', 'display:none');
    $('#btnSalary').attr('style', 'display:none');
}

function DisableAll() {
    $('#Name').attr('disabled', 'disabled');
    $('#DateOfBirth').attr('disabled', 'disabled');
    $('#TIN').attr('disabled', 'disabled');
    $('#ddlEmployeeType').attr('disabled', 'disabled');
}

function EnableAll() {
    $('#Name').removeAttr('disabled');
    $('#DateOfBirth').removeAttr('disabled');
    $('#TIN').removeAttr('disabled');
    $('#ddlEmployeeType').removeAttr('disabled');
}

function Validate() {
    $('#Name').valid();
    $('#DateOfBirth').valid();
    $('#TIN').valid();
}
