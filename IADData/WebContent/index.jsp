<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="s" uri="/struts-tags" %>
<!DOCTYPE HTML>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>Highstock Example</title>

		<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
		<style type="text/css">
${demo.css}
		</style>
		<script type="text/javascript">
$(function () {

    Highcharts.setOptions({
        global : {
            useUTC : false
        }
    });

    // Create the chart
    $('#container').highcharts('StockChart', {
        chart : {
            events : {
                load : function () {

                    // set up the updating of the chart each second
                    var series = this.series[0];
                    setInterval(function () {
                    	
                        var x = (new Date()).getTime(), // current time
                            y = Math.round(Math.random() * 100);
                        $.getJSON('/light/json/getJson', function (data) {
                        	
                        	y=data.data[0].ledRead;
                        	//alert(y);
                        	x=(new Date(data.data[0].time)).getTime();
                        	console.log("x:"+x);
                        	console.log("y:"+y);
                        	series.addPoint([x, y], true, true);
                        }); 
                        
                    }, 1000);
                }
            }
        },

        rangeSelector: {
            buttons: [{
                count: 1,
                type: 'minute',
                text: '1M'
            }, {
                count: 5,
                type: 'minute',
                text: '5M'
            }, {
                type: 'all',
                text: 'All'
            }],
            inputEnabled: false,
            selected: 0
        },

        title : {
            text : 'Light data'
        },

        exporting: {
            enabled: false
        },

        series : [{
            name : 'Random data',
            data : (function () {
                // generate an array of random data
                var Ldata = [], time = (new Date()).getTime(), i;
				var lightdata =[];
                for (i = -9; i <= 0; i += 1) {
						
						Ldata.push([
						   "",
						   i
						]);
                }
                return Ldata;
            }())
        }]
    });

});

		</script>
	</head>
	<body>
<script src="js/highstock.js"></script>
<script src="js/modules/exporting.js"></script>

<div id="container" style="height: 400px; min-width: 310px"></div>
	</body>
</html>
