import { Directive ,Input , HostListener } from '@angular/core';

@Directive({
  selector: '[appScrollTo]'
})
export class ScrollToDirective {
  @Input() target = '';
  @HostListener('click') OnClick(){
    console.log(this.target);
  }

  constructor() { }

}
