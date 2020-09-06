// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var frmRegElectricMeter = $('#frmRegElectricMeter');
    if (frmRegElectricMeter.length > 0)
        ElectricMeter.register();

    var frmRegWaterMeter = $('#frmRegWaterMeter');
    if (frmRegWaterMeter.length > 0)
        WaterMeter.register();

    var frmRegGateway = $('#frmRegGateway');
    if (frmRegGateway.length > 0)
        Gateway.register();
});

var ElectricMeter = {
    register: function () {
        var frmRegElectricMeter = $('#frmRegElectricMeter');
        frmRegElectricMeter.submit(function (e) {
            e.preventDefault();
            $('#msg').removeClass().html('');
            if (frmRegElectricMeter.valid()) {
                $.ajax({
                    url: frmRegElectricMeter.attr('action'),
                    method: frmRegElectricMeter.attr('method'),
                    data: frmRegElectricMeter.serialize(),
                    success: function (data) {
                        if (data.success) {
                            $('#msg').removeClass().addClass('text-success').html(data.message);
                            ElectricMeter.appendRecord(data.data);
                            frmRegElectricMeter.trigger('reset');
                        }
                        else if (data.message === 'INVALID_INPUT')
                            ElectricMeter.displayInvalidInputMessage(data.data);
                        else
                            $('#msg').removeClass().addClass('text-danger').html(data.message);
                    },
                    error: function () {
                        $('#msg').removeClass().addClass('text-danger').html('An error has occured');
                    }
                })
            }
        });
    },
    displayInvalidInputMessage: function (data) {
        var html = '';
        if (data instanceof Array && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                if (i > 0)
                    html += '<br/>';
                html += data[i].errorMessage;
            }
        }
        $('#msg').removeClass().addClass('text-danger').html(html);
    },
    appendRecord: function (data) {
        var html = '<tr>';
        html += '<th scope="row">' + data.id + '</th>';
        html += '<td>' + (data.serialNumber || "") + '</td>';
        html += '<td>' + (data.firmwareVersion || "") + '</td>';
        html += '<td>' + (data.state || "") + '</td>';
        html += '</tr>';
        $('#tblElectricMeter').removeClass('d-none');
        $('#tblElectricMeter tbody').append(html);
    }
};

var WaterMeter = {
    register: function () {
        var frmRegWaterMeter = $('#frmRegWaterMeter');
        frmRegWaterMeter.submit(function (e) {
            e.preventDefault();
            $('#msg').removeClass().html('');
            if (frmRegWaterMeter.valid()) {
                $.ajax({
                    url: frmRegWaterMeter.attr('action'),
                    method: frmRegWaterMeter.attr('method'),
                    data: frmRegWaterMeter.serialize(),
                    success: function (data) {
                        if (data.success) {
                            $('#msg').removeClass().addClass('text-success').html(data.message);
                            WaterMeter.appendRecord(data.data);
                            frmRegWaterMeter.trigger('reset');
                        }
                        else if (data.message === 'INVALID_INPUT')
                            WaterMeter.displayInvalidInputMessage(data.data);
                        else
                            $('#msg').removeClass().addClass('text-danger').html(data.message);
                    },
                    error: function () {
                        $('#msg').removeClass().addClass('text-danger').html('An error has occured');
                    }
                })
            }
        });
    },
    displayInvalidInputMessage: function (data) {
        var html = '';
        if (data instanceof Array && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                if (i > 0)
                    html += '<br/>';
                html += data[i].errorMessage;
            }
        }
        $('#msg').removeClass().addClass('text-error').html(html);
    },
    appendRecord: function (data) {
        var html = '<tr>';
        html += '<th scope="row">' + data.id + '</th>';
        html += '<td>' + (data.serialNumber || "") + '</td>';
        html += '<td>' + (data.firmwareVersion || "") + '</td>';
        html += '<td>' + (data.state || "") + '</td>';
        html += '</tr>';
        $('#tblWaterMeter').removeClass('d-none');
        $('#tblWaterMeter tbody').append(html);
    }
};

var Gateway = {
    register: function () {
        var frmRegGateway = $('#frmRegGateway');
        frmRegGateway.submit(function (e) {
            e.preventDefault();
            $('#msg').removeClass().html('');
            if (frmRegGateway.valid()) {
                $.ajax({
                    url: frmRegGateway.attr('action'),
                    method: frmRegGateway.attr('method'),
                    data: frmRegGateway.serialize(),
                    success: function (data) {
                        if (data.success) {
                            $('#msg').removeClass().addClass('text-success').html(data.message);
                            Gateway.appendRecord(data.data);
                            frmRegGateway.trigger('reset');
                        }
                        else if (data.message === 'INVALID_INPUT')
                            Gateway.displayInvalidInputMessage(data.data);
                        else
                            $('#msg').removeClass().addClass('text-danger').html(data.message);
                    },
                    error: function () {
                        $('#msg').removeClass().addClass('text-danger').html('An error has occured');
                    }
                })
            }
        });
    },
    displayInvalidInputMessage: function (data) {
        var html = '';
        if (data instanceof Array && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                if (i > 0)
                    html += '<br/>';
                html += data[i].errorMessage;
            }
        }
        $('#msg').removeClass().addClass('text-danger').html(html);
    },
    appendRecord: function (data) {
        var html = '<tr>';
        html += '<th scope="row">' + data.id + '</th>';
        html += '<td>' + (data.serialNumber || "") + '</td>';
        html += '<td>' + (data.firmwareVersion || "") + '</td>';
        html += '<td>' + (data.state || "") + '</td>';
        html += '<td>' + (data.ip || "") + '</td>';
        html += '<td>' + (data.port || "") + '</td>';
        html += '</tr>';
        $('#tblGateway').removeClass('d-none');
        $('#tblGateway tbody').append(html);
    }
};