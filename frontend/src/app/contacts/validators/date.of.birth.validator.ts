import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function dateOfBirthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return { required: true };
    }

    const dateOfBirth = new Date(value);

    // Check if the date of birth is in the future
    if (dateOfBirth > new Date()) {
      return { futureDate: true };
    }

    // Check if the date of birth is older than 100 years
    const maxDate = new Date();
    maxDate.setFullYear(maxDate.getFullYear() - 100);

    if (dateOfBirth < maxDate) {
      return { olderThan100Years: true };
    }

    return null; // Date of birth is valid
  };
}
