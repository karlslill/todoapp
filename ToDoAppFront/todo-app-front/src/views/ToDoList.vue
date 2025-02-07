<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';
import { ToDoTaskApi } from '../api/api'; 
import { RouterLink } from 'vue-router'

const tasks = ref([]); 
const filterText = ref(''); 
const filterStatus = ref('all'); 
const api = new ToDoTaskApi()
const dueDate = ref('');

// Fetch all tasks
const fetchTasks = async () => {
  try {
    const response = await api.apiToDoTaskGet();
    tasks.value = response.data;
  } catch (error) {
    console.error('Error fetching tasks:', error);
  }
};

onMounted(fetchTasks);

const fetchFilteredTasks = async () => {

  try {
    const search = filterText.value || undefined; 
    const dueDateFilter = dueDate.value || undefined; 
    const isDoneFilter = filterStatus.value !== '' ? (filterStatus.value === 'true') : undefined

    const response = await api.apiToDoTaskGet(search, isDoneFilter, dueDateFilter);
    tasks.value = response.data; 
  } finally{

  }
};
</script>

<template>
  <div class="todo-list">
    <h1>To-Do List</h1>

    <div class="filters">
      <label for="description">Search by Description:</label>
      <input type="text" v-model="filterText" id="description" placeholder="Search by task description" />

      <label for="status">Status:</label>
      <select v-model="filterStatus" id="status">
        <option value="">All</option>
        <option value="true">Completed</option>
        <option value="false">Pending</option>
      </select>

      <label for="dueDate">Due Date:</label>
      <input type="date" v-model="dueDate" id="dueDate" />

      <button @click="fetchFilteredTasks">Search</button>
    </div>

    <ul>
      <li v-for="task in tasks" :key="task.id">
        <router-link :to="{ name: 'EditToDo', params: { id: task.id } }">
          <span >{{ task.title }}</span>
          <span class="date">Due: {{ new Date(task.dueDate).toLocaleDateString() }}</span>
        </router-link>
      </li>
    </ul>
  </div>
</template>
  
 
  
<style scoped>
.todo-list {
  max-width: 600px;
  margin: 0 auto;
  text-align: center;
}

.filters {
  margin-bottom: 15px;
}

.filters input,
.filters select {
  margin: 5px;
  padding: 8px;
  font-size: 16px;
}

ul {
  list-style-type: none; 
  padding: 0;
  margin: 0;
  font-family: Arial, sans-serif;
}

li {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: #f9f9f9;
  padding: 10px;
  border-radius: 5px;
  margin-bottom: 8px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s;
}

li:hover {
  background-color: #e0f7fa; 
}

li span {
  font-size: 16px;
  color: #333;
}

li .date {
  font-size: 14px;
  color: #555;
}

li span:first-child {
  font-weight: bold;
  margin-right: 30px;
}

li .date {
  text-align: right; 
  color: #999; 
}


.done {
  text-decoration: line-through;
  color: gray;
}

.date {
  font-size: 14px;
  color: #555;
}
</style>
  