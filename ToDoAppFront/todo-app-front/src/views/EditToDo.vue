  <script setup lang="ts">
  import { ref, onMounted } from "vue";
  import { useRoute, useRouter } from "vue-router";
  import { ToDoTaskApi } from '../api/api'; 
  
  const api = new ToDoTaskApi()

  
      const task = ref({
        id: null,
        title: "",
        description: "",
        createdAt: "",
        dueDate: "",
        isDone: false,
        parentId: null,
        parent: null,
        subTodos: [],
      });
  
      const route = useRoute();
      const router = useRouter();
  
      const loadTask = async () => {
        try {
          const response = await api.apiToDoTaskIdGet(route.params.id);
          task.value = response.data;
        } catch (error) {
          console.error("Error fetching task:", error);
        }
      };
  
      const updateTask = async () => {
        try {
          await api.apiToDoTaskIdPut(task.value.id, task.value);
          router.push("/");
        } catch (error) {
          console.error("Error updating task:", error);
        }
      };
  
      const deleteTask = async () => {
        try {
          await api.apiToDoTaskIdDelete(task.value.id);
          router.push("/"); 
        } catch (error) {
          console.error("Error deleting task:", error);
        }
      };
  
      onMounted(() => {
        loadTask();
      });
  </script>
  
  <template>
    <div class="edit-todo">
      <h1>Edit Task</h1>
      <form @submit.prevent="updateTask">
        <div class="form-group">
          <label for="title">Title:</label>
          <input
            type="text"
            id="title"
            v-model="task.title"
            required
            placeholder="Enter task title"
          />
        </div>
  
        <div class="form-group">
          <label for="description">Description:</label>
          <textarea
            id="description"
            v-model="task.description"
            placeholder="Enter task description"
          ></textarea>
        </div>
  
        <div class="form-group">
          <label for="dueDate">Due Date:</label>
          <input
            type="date"
            id="dueDate"
            v-model="task.dueDate"
          />
        </div>
  
        <div class="form-group">
          <label>
            <input
              type="checkbox"
              v-model="task.isDone"
            />
            Task Completed
          </label>
        </div>
  
        <button type="submit" class="submit-btn">Update Task</button>
        <button
          type="button"
          class="delete-btn"
          @click="deleteTask"
        >
          Delete Task
        </button>
      </form>
    </div>
  </template>
  

  
  <style scoped>
  .edit-todo {
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 8px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  }
  
  h1 {
    text-align: center;
    margin-bottom: 20px;
  }
  
  .form-group {
    margin-bottom: 15px;
  }
  
  label {
    display: block;
    font-weight: bold;
    margin-bottom: 5px;
  }
  
  input,
  textarea {
    width: 100%;
    padding: 8px;
    margin-top: 5px;
    border-radius: 4px;
    border: 1px solid #ccc;
  }
  
  textarea {
    resize: vertical;
    height: 100px;
  }
  
  button {
    padding: 10px 20px;
    border: none;
    background-color: #007bff;
    color: white;
    font-size: 16px;
    border-radius: 5px;
    cursor: pointer;
    margin-top: 20px;
  }
  
  button:disabled {
    background-color: #ccc;
    cursor: not-allowed;
  }
  
  button.submit-btn {
    background-color: #28a745;
  }
  
  button.delete-btn {
    background-color: #dc3545;
    margin-top: 10px;
  }
  
  button:hover {
    opacity: 0.9;
  }
  
  button.delete-btn:hover {
    background-color: #c82333;
  }
  </style>
  