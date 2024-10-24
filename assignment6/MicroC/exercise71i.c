void main(int n) {
  int[] arr[4];
  arr[0] = 7;
  arr[1] = 13;
  arr[2] = 9;
  arr[3] = 8;

  int printer;
  printer = 0;

  print arrsum(n, arr, &printer);
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;
    while (i < n){
        sump = sump + arrs[i];
        i = i + 1;
    }
}