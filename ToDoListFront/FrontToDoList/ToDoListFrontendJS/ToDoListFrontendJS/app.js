const apiBaseUrl = "https://localhost:7150/api/ToDoList"; // URL base de la API
const inputBox = document.querySelector("#inputbox");
const list = document.querySelector("#list");

// Función para cargar las tareas desde la API
async function loadTasks() {
    try {
        const response = await fetch(`${apiBaseUrl}/GetTasks/get-task`);
        if (!response.ok) {
            throw new Error("Error al cargar las tareas");
        }
        const tasks = await response.json();
        console.log("Tasks from API:", tasks);  // Verifica los datos aquí
        tasks.forEach(task => {
            addItemToDOM(task);  // Llamamos a la función para agregar las tareas al DOM
        });

    } catch (error) {
        console.error("Error loading tasks:", error);
    }
}

// Cargar las tareas al iniciar la aplicación
loadTasks();

// Función para agregar una tarea a la API
async function addTask(taskName) {
    try {
        const fechaActual = new Date().toLocaleString(); // Obtiene la fecha y hora actual
        const response = await fetch(`${apiBaseUrl}/PostTask/post-task`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                Nombre: taskName, // Nombre de la tarea
                Estado: "In Progress", // Estado inicial
                Descripcion: `Creada el: ${fechaActual}` // Descripción con la fecha
                
            })
        
        });

        if (!response.ok) {
            const errorData = await response.json(); // Lee el mensaje de error de la API
            throw new Error(`Error al agregar la tarea: ${errorData.message || response.statusText}`);
        }

        const newTask = await response.json();
        addItemToDOM(newTask); // Agrega la tarea al DOM
    } catch (error) {
        console.error("Error adding task:", error);
    }
}

// Función para actualizar el estado de una tarea en la API
async function updateTaskStatus(taskid, status) {
    try {
        const response = await fetch(`${apiBaseUrl}/PutTask/put-task/${taskid}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ estado: status }) // Actualizamos solo el estado
        });
        if (!response.ok) {
            throw new Error("Error al actualizar la tarea");
        }
    } catch (error) {
        console.error("Error updating task status:", error);
    }
}


async function deleteTask(taskId) {
    try {
        console.log("Eliminando tarea con ID:", taskId);
        const response = await fetch(`${apiBaseUrl}/DeletePersona/delete-task?id=${taskId}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            throw new Error(`Error al eliminar la tarea: ${response.status} ${response.statusText}`);
        }

        console.log("Tarea eliminada exitosamente");
        return true;  // ✅ Retorna true si la eliminación fue exitosa
    } catch (error) {
        console.error("Error deleting task:", error);
        return false;  // ❌ Retorna false si hubo un error
    }
}

// Función para agregar una tarea al DOM
function addItemToDOM(task) {
    // Crear un nuevo <li> para cada tarea
    let listItem = document.createElement("li");

    // Mostrar el nombre de la tarea y el botón de eliminar
    listItem.innerHTML = `${task.nombre} <i class="delete-btn"></i>`; // Mostrar nombre de la tarea y el botón de eliminar

    // Asignar el ID de la tarea al atributo data-task-id del <li>
    listItem.setAttribute("data-task-id", task.id);  // Asignamos el ID de la tarea

    // Si la tarea está completada, añadir la clase 'done'
    if (task.estado === "Done") {
        listItem.classList.add('done');
    }

    // Agregar evento para cambiar el estado de la tarea al hacer clic en el <li>
    listItem.addEventListener("click", function () {
        const newStatus = this.classList.contains('done') ? "In Progress" : "Done";
        this.classList.toggle('done');
        updateTaskStatus(task.id, newStatus);
    });

    // Agregar el nuevo <li> al contenedor de la lista
    list.appendChild(listItem);

    // Agregar un evento para eliminar la tarea al hacer clic en el botón de eliminar
    listItem.querySelector(".delete-btn").addEventListener("click", function (event) {
        event.stopPropagation();  // Evitar que el clic en el botón active el evento del li
        const taskId = listItem.getAttribute("data-task-id");  // Obtener el ID de la tarea desde el atributo data-task-id
        deleteTask(taskId);  // Llamar a la función para eliminar la tarea de la API
        listItem.remove();  // Eliminar el <li> del DOM
    });
}


inputBox.addEventListener("keyup", function (event) {
    if (event.key === "Enter" && inputBox.value.trim() !== "") {
        const taskName = inputBox.value.trim(); // Asignación explícita
        addTask(taskName); // Llamada a la función con el valor asignado
        inputBox.value = ""; // Limpia el campo de texto
    }
});