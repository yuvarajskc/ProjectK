import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgFor } from '@angular/common';
import { TodoService } from './todo.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor,FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MyAngularApp';
  todoList = [
    { name: 'Task 1', isComplete: false },
    { name: 'Task 2', isComplete: true }
  ];
  newTodo = { name: '', isComplete: false };

  constructor(private todoService: TodoService) { 
  }

  ngOnInit() {
    this.fetchTodos();
  }

  addTodo() {
    if (this.newTodo.name.trim()) {
      this.todoService.addTodo(this.newTodo).subscribe(
        (response) => {
          this.todoList.push(response);
          this.newTodo = { name: '', isComplete: false };
        },
        (error) => {
          console.error('Error adding todo:', error);
        }
      );
    }
  }

  fetchTodos() {
    this.todoService.getTodos().subscribe(
      (todos) => {
        this.todoList = todos;
      },
      (error) => {
        console.error('Error fetching todos:', error);
      }
    );
  }
}