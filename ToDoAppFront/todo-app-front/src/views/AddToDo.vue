<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { ToDoTaskApi } from '../api/api'; 

const title = ref('');
const description = ref('');
const parentId = ref(null);
const dueDate = ref(new Date().toISOString().split('T')[0]);
const parentTasks = ref([]);
const router = useRouter();
const api = new ToDoTaskApi()

const fetchParentTasks = async () => {
  try {
    const response = await api.apiToDoTaskGet();
    parentTasks.value = response.data;
  } catch (error) {
    console.error('Error fetching parent tasks:', error);
  }
};

onMounted(fetchParentTasks);

const addToDo = async () => {
  const newTask = {
    id: 0,
    title: title.value,
    description: description.value,
    createdAt: new Date().toISOString(),
    dueDate: new Date(dueDate.value).toISOString(),
    isDone: false,
    parentId: parentId.value || null,
    Parent: null, 
    SubTodos: [] 
  };

  try {
    await api.apiToDoTaskPost(newTask);
    router.push('/');
  } catch (error) {
    console.error('Error adding task:', error);
  }
};
</script>

<template>
  <div class="add-todo">
    <h1>Add a New ToDo Task</h1>
    <form @submit.prevent="addToDo">
      <label for="title">Title:</label>
      <input type="text" id="title" v-model="title" required />

      <label for="description">Description:</label>
      <textarea id="description" v-model="description" required></textarea>

      <label for="dueDate">Due Date:</label>
      <input type="date" id="dueDate" v-model="dueDate" required />

      <label for="parentId">Parent Task (Optional):</label>
      <select id="parentId" v-model="parentId">
        <option value="">None</option>
        <option v-for="task in parentTasks" :key="task.id" :value="task.id">
          {{ task.title }}
        </option>
      </select>

      <button type="submit">Add Task</button>
    </form>
  </div>
</template>

<style scoped>
.add-todo {
  max-width: 500px;
  margin: 0 auto;
  text-align: center;
}

form {
  display: flex;
  flex-direction: column;
  align-items: center;
}

label {
  margin-top: 10px;
  font-weight: bold;
}

input,
textarea,
select {
  width: 100%;
  margin-bottom: 15px;
  padding: 8px;
  font-size: 16px;
}

button {
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
  width: 100%;
}

button:hover {
  background-color: #0056b3;
}
</style>
