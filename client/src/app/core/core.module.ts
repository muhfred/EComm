import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreComponent } from './core.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    NavBarComponent,
     CoreComponent
    ],
  imports: [
    CommonModule
  ],
  exports: [
    NavBarComponent
  ]
})
export class CoreModule { }
