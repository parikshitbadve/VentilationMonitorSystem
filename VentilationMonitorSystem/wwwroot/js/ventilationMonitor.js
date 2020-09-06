var dataTable;
var departmentCapcityDetail = [];
$(document).ready(function () {
    //var differed=
    //    loadData().then(ValidateData());
    //$.when(loadData()).then(function () {
    //    ValidateData();
    loadData();
    //});
    
});

var loadData = function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/ventilationMonitor/GetVentilationMonitorData",
            "type": "GET",
            "datatype": "json",

            // to get Department object
            "dataSrc": function (resp) {
                departmentCapcityDetail = resp.data1;
                return resp.data;
            }
        },

        // this event check footer logic

        "fnInitComplete": function () {
            //alert('DataTables has finished its initialisation.');
            // ValidateData();
            var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
            $('#tblData tbody').append(newRow);
            ValidateData();
        },
        // calculate sum of each column
        "footerCallback": function (row, data, start, end, display) {
            totalLogWall = this.api()
                .column(1)
                .data()
                .reduce(function (a, b) {
                    return parseInt(a) + parseInt(b);
                }, 0);
            $('.totlLogwall').html(totalLogWall);

            totalTelligate = this.api()
                .column(2)
                .data()
                .reduce(function (a, b) {
                    return parseInt(a) + parseInt(b);
                }, 0);
            $('.totlTeligate').html(totalTelligate);

            totalMg13 = this.api()
                .column(3)
                .data()
                .reduce(function (a, b) {
                    return parseInt(a) + parseInt(b);
                }, 0);
            $('.totlMG13').html(totalMg13);

            totalMg14 = this.api()
                .column(4)
                .data()
                .reduce(function (a, b) {
                    return parseInt(a) + parseInt(b);
                }, 0);
            $('.totlMG14').html(totalMg14);

            //ValidateData();
            //var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
            //$('#tblData tbody').append(newRow)

        },
        "columns": [
            { "data": "unit", "width": "20%" },
            { "data": "longWall", "width": "10%" },
            { "data": "taligate", "width": "10%" },
            { "data": "mG13", "width": "10%" },
            { "data": "mG14", "width": "10%" },
            {
                "data": "recordId",
                "render": function (data) {

                    return `<div class="text-center">
                                <a onclick=Delete("/VentilationMonitor/RemoveRecord/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                            `;
                }, "width": "30%"
            }
        ]
    });

    
    $('.dataTables_filter input').unbind().bind("input", function (e) {
        
        var table = $('tblData').dataTable();
        filterColumn(this.value);;
    });

    $('.dataTables_length select').on('change', function () {
        console.log('New page length: ' + $(this).val());
        ValidateData();
        var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
        $('#tblData tbody').append(newRow);

    });
   
}

// Create Custom Filter to maintain footer value and New record button
function filterColumn(val) {
    $('#tblData').DataTable().column().search(val).draw();
    ValidateData();
    var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
    $('#tblData tbody').append(newRow);
};

var ValidateData = function GetDepartmentDetails() {
  
    $.each(departmentCapcityDetail, function (index, obj) {
                $('#footerRow>th').each(function (key, value) {
                    var counter = key+1;
                    if ($('.theader th:nth-child(' + counter + ')').html().toLowerCase() == obj.departmentName.toLowerCase()) {
                        var html = $(this).html();

                        if (parseInt(html) > obj.ventilationCapacity) {
                            $(this).html('<span style="color:red";>' + html + '/' + obj.ventilationCapacity+'</span>' );
                        }
                        else {

                            $(this).html(html + '/' + obj.ventilationCapacity);
                        }
                    }
                })
            });
   
}

function AddNewRecord() {
    
    $('#tblData').DataTable().column().search("").draw();
    ValidateData();
    var html="<tr class='newrow'>"
        +"<td><input type='text' id='rowunit' style='width:100%' name='rowunit' ></td>"
         +"<td><input type='number' id='rowlongwall' name='rowlongwall' value='0'></td>"
        +"<td><input type='number' id='rowtailgate' name='rowtailgate' value='0'></td>"
        +"<td><input type='number' id='rowMaingate13' name='rowmaingate13' value='0'></td>"
        + "<td><input type='number' id='rowmaingate14' name='rowmaingate14' value='0'></td>"
        + "<td class='text-center'> <a class='btn btn-success text-white'style = 'cursor:pointer;' onclick='AddRecord(this)' > <i class='far fa-edit'></i></a>&nbsp;&nbsp;&nbsp;&nbsp;"
        + "<a class='btn btn-success text-white'style = 'cursor:pointer;' onclick='DeleteRow(this)' > <i class='fa fa-close'></i></a >"
        +"</td > "
        + "</tr>"
    if ($('#tblData tbody .newrow').length == 0) {
        $('#tblData tbody tr:last').after(html);
    }
   // $('#tblData tbody').append(html);
};

function AddRecord(obj) {
    if ($('#rowunit').val() == '')
        alert('Unit filed is mandetory!');
    return;
    var data = { "Unit": $('#rowunit').val(), "LongWall": $('#rowlongwall').val(), "Taligate": $('#rowtailgate').val(), "MG13": $('#rowMaingate13').val(), "MG14": $('#rowmaingate14').val() };
    $.ajax({
        type: 'POST',
        url: '/VentilationMonitor/AddRecord',
        data:data,
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload(function () {
                    ValidateData();
                    var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
                    $('#tblData tbody').append(newRow);
                });
            }
            else {
                toastr.error(data.message);
            }
        }
    });
}
function DeleteRow(obj) {
    $('.newrow').remove();
}
function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload(function () {
                            ValidateData();
                            var newRow = "<tr><td colspan='6'><a class='btn btn-success text-white' id='lnkaddrow' onclick='AddNewRecord()' style='cursor:pointer;'> <i class='fa fa-plus'></i></a></td></tr>";
                            $('#tblData tbody').append(newRow);
                        });
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

//<tr id=""><th>Total</th><th class="totlLogwall"></th><th class="totlTeligate"></th><th class="totlMG13"></th><th class="totlMG14"></th></tr>