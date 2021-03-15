#include <stdio.h>

/* print Fahrenheit-Celcsius table
    for fahr = 0, 20, ..., 300; floating-point version */
main()
{
    float fahr, celcius;
    int lower, upper, step;

    lower = 0;      /* lower limit of temperature table */
    upper = 300;    /* upper limit */
    step = 20;      /* step size */

    printf("Celcsius-Fahrenheit table:\n\n");
    printf("Celsius\t\tFahrenheit\n");

    celcius = lower;
    while (celcius <= upper) {
        fahr = (9.0/5.0 * celcius) + 32.0;
        printf("%3.0f\t\t%5.0f\n", celcius, fahr);
        celcius = celcius + step;
    }
}