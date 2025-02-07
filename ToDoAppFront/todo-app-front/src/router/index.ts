import { createRouter, createWebHistory } from 'vue-router';
import AddToDo from '../views/AddToDo.vue';
import ToDoList from '../views/ToDoList.vue';
import EditToDo from '../views/EditToDo.vue';

const routes = [
  {
    path: '/',
    name: 'ToDoList',
    component: ToDoList
  },
  {
    path: '/add',
    name: 'AddToDo',
    component: AddToDo
  },
  {
    path: '/edit/:id',
    name: 'EditToDo',
    component: EditToDo,
    props: true
  }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

export default router;