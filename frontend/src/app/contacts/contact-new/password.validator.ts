import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function passwordValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null;
    }

    // Password has to be at least 8 characters long
    if (value.length < 8) {
      return { minlength: true };
    }

    // Password has to be max 100 characters long
    if (value.length > 100) {
      return { maxlength: true };
    }

    // Password has to contain at least one uppercase letter
    if (!/[A-Z]+/.test(value)) {
      return { uppercase: true };
    }

    // Password has to contain at least one lowercase letter
    if (!/[a-z]+/.test(value)) {
      return { lowercase: true };
    }

    // Password has to contain at least one number
    if (!/\d+/.test(value)) {
      return { number: true };
    }

    // Password has to contain at least one special character (!?*.)
    if (!/[\!\?\*\.]+/.test(value)) {
      return { specialCharacter: true };
    }

    return null; // Password is valid
  };
}
