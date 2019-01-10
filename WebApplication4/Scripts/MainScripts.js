function searchForCourses(inputName, tableName) {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById(inputName);
    filter = input.value.toUpperCase();
    table = document.getElementById(tableName);
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function sortTable(n, tableName) {
    console.log("sorting on " + n);
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById(tableName);
    switching = true;
    dir = "asc";
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}
function successFunction(data) {
    var str = data;

    var courses_data = str.split('\n');

    var table_data = '<table class="coursesTable>" id="coursesTable"';
    table_data += '<tr class="coursesTr">';
    table_data += '<th onclick="sortTable(0,\'' + "coursesTable" + '\')" class="coursesTh">Course</th>';
    table_data += '<th onclick="sortTable(1,\'' + "coursesTable" + '\')" class="coursesTh">Instructor</th>';
    table_data += '<th onclick="sortTable(2,\'' + "coursesTable" + '\')" class="coursesTh">Day</th>';
    table_data += '<th onclick="sortTable(3,\'' + "coursesTable" + '\')" class="coursesTh">Starts</th>';
    table_data += '<th onclick="sortTable(4,\'' + "coursesTable" + '\')" class="coursesTh">Ends</th>';
    table_data += '<th onclick="sortTable(5,\'' + "coursesTable" + '\')" class="coursesTh">Room</th>';
    table_data += '<th onclick="sortTable(6,\'' + "coursesTable" + '\')" class="coursesTh">Type</th>';
    table_data += '</tr>';

    for (var count = 0; count < courses_data.length; count++) {
        var cell_data = courses_data[count].trim().split(",");
        table_data += '<tr class="coursesTr">';
        for (var cell_count = 0; cell_count < cell_data.length; cell_count++) {
            table_data += '<td class="coursesTd">' + cell_data[cell_count] + '</td>';
        }
        table_data += '</tr>';
    }
    table_data += '</table>';
    $('#courses_table').html(table_data);
}
function successFunctionPeople(data) {
    var str = data;

    var courses_data = str.split('\n');

    var table_data = '<table class="peopleSearchTable>" id="peopleSearchTable"';
    table_data += '<tr class="coursesTr">';
    table_data += '<th onclick="sortTable(0,\'' + "peopleSearchTable" + '\')" class="coursesTh">First name</th>';
    table_data += '<th onclick="sortTable(1,\'' + "peopleSearchTable" + '\')" class="coursesTh">Second name</th>';
    table_data += '<th onclick="sortTable(2,\'' + "peopleSearchTable" + '\')" class="coursesTh">Room</th>';
    table_data += '<th onclick="sortTable(3,\'' + "peopleSearchTable" + '\')" class="coursesTh">Phone</th>';
    table_data += '<th onclick="sortTable(4,\'' + "peopleSearchTable" + '\')" class="coursesTh">Email</th>';
    table_data += '</tr>';

    for (var count = 0; count < courses_data.length; count++) {
        var cell_data = courses_data[count].trim().split(",");
        table_data += '<tr class="coursesTr">';
        for (var cell_count = 0; cell_count < cell_data.length; cell_count++) {
            table_data += '<td class="coursesTd">' + cell_data[cell_count] + '</td>';
        }
        table_data += '</tr>';
    }
    table_data += '</table>';
    $('#people_search_table').html(table_data);
}
function successFunctionCourses(data) {
    var str = data;

    var courses_data = str.split('\n');

    var table_data = '<table class="coursesSearchTable>" id="coursesSearchTable"';
    table_data += '<tr class="coursesTr">';
    table_data += '<th onclick="sortTable(0,\'' + "coursesSearchTable" + '\')" class="coursesTh">Course</th>';
    table_data += '<th onclick="sortTable(1,\'' + "coursesSearchTable" + '\')" class="coursesTh">Instructor</th>';
    table_data += '<th onclick="sortTable(2,\'' + "coursesSearchTable" + '\')" class="coursesTh">Day</th>';
    table_data += '<th onclick="sortTable(3,\'' + "coursesSearchTable" + '\')" class="coursesTh">Starts</th>';
    table_data += '<th onclick="sortTable(4,\'' + "coursesSearchTable" + '\')" class="coursesTh">Ends</th>';
    table_data += '<th onclick="sortTable(5,\'' + "coursesSearchTable" + '\')" class="coursesTh">Room</th>';
    table_data += '<th onclick="sortTable(6,\'' + "coursesSearchTable" + '\')" class="coursesTh">Type</th>';
    table_data += '<th onclick="sortTable(7,\'' + "coursesSearchTable" + '\')" class="coursesTh">Number of students</th>';
    table_data += '<th onclick="sortTable(8,\'' + "coursesSearchTable" + '\')" class="coursesTh">Places available</th>';
    table_data += '<th onclick="sortTable(9,\'' + "coursesSearchTable" + '\')" class="coursesTh">Examination</th>';
    table_data += '</tr>';

    for (var count = 0; count < courses_data.length; count++) {
        var cell_data = courses_data[count].trim().split(",");
        table_data += '<tr class="coursesTr">';
        for (var cell_count = 0; cell_count < cell_data.length; cell_count++) {
            table_data += '<td class="coursesTd">' + cell_data[cell_count] + '</td>';
        }
        table_data += '</tr>';
    }
    table_data += '</table>';
    $('#courses_search_table').html(table_data);
}
function successFunctionMarketplace(data) {
    var str = data;
    var courses_data = str.split('\n');

    var table_data = '<table class="coursesSearchTable>" id="coursesSearchTable"';
    table_data += '<tr class="coursesTr">';
    table_data += '<th onclick="sortTable(0,\'' + "coursesSearchTable" + '\')" class="coursesTh">Przedmiot</th>';
    table_data += '<th onclick="sortTable(1,\'' + "coursesSearchTable" + '\')" class="coursesTh">Prowadzący</th>';
    table_data += '<th onclick="sortTable(2,\'' + "coursesSearchTable" + '\')" class="coursesTh">Sesja</th>';
    table_data += '<th onclick="sortTable(3,\'' + "coursesSearchTable" + '\')" class="coursesTh">ECTS</th>';
    table_data += '<th onclick="sortTable(4,\'' + "coursesSearchTable" + '\')" class="coursesTh">Wydział</th>';
    table_data += '</tr>';

    for (var count = 0; count < courses_data.length; count++) {
        var cell_data = courses_data[count].trim().split(",");
        table_data += '<tr class="coursesTr">';
        for (var cell_count = 0; cell_count < cell_data.length; cell_count++) {
            table_data += '<td class="coursesTd">' + cell_data[cell_count] + '</td>';
        }
        table_data += '</tr>';
    }
    table_data += '</table>';
    $('#search_subjects').html(table_data);
}
