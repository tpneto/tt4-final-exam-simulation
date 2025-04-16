// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { TaskService } from './services/task.service';
import { Task } from './models/task';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false
})
export class AppComponent implements OnInit {
  tasks: Task[] = [];
  form: FormGroup;

  constructor(private taskService: TaskService, private fb: FormBuilder) {
    this.form = fb.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe((data) => (this.tasks = data));
  }

  createTask() {
    if(this.form.invalid)
      return;

    const { title, description } = this.form.value;

    const task : Task = {
      title,
      description,
      completed: false
    };

    this.taskService.createTask(task).subscribe(() => {
      this.form.reset();
      this.form.markAsPristine();
      this.form.markAsUntouched();
      this.loadTasks();
    });
  }

  deleteTask(id: number) {
    this.taskService.deleteTask(id).subscribe(() => this.loadTasks());
  }

  toggleComplete(task: Task) {
    task.completed = !task.completed;
    this.taskService.updateTask(task).subscribe();
  }
}
