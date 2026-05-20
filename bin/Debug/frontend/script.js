        fetch("https://student-finance-api.onrender.com/students")
            .then(response => response.json())
            .then(data => {

                const tableBody = document.getElementById("studentTableBody");

                data.forEach(student => {

                    const row = `
                        <tr>
                            <td>${student.student_id}</td>
                            <td>${student.student_name}</td>
                            <td>${student.student_email}</td>
                            <td>
                                <span class="status active">
                                    Active
                                </span>
                            </td>
                        </tr>
                    `;

                    tableBody.innerHTML += row;
                });

            })
            .catch(error => {
                console.error("Error fetching students:", error);
            });