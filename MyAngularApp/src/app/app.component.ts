import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgFor } from '@angular/common';
import { TodoService } from './todo.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Todo App';
  todoList: any[] = [];

  constructor(private todoService: TodoService) { 
  }

  ngOnInit() {
    this.todoService.getList().subscribe(data => {
      this.todoList = data;
    });
  }
}