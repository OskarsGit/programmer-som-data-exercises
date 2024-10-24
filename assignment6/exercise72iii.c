void main(int n) {
  int arr[7];
  arr[0] = 1;
  arr[1] = 2;
  arr[2] = 1;
  arr[3] = 1;
  arr[4] = 1;
  arr[5] = 2;
  arr[6] = 0;
  int max;
  max = 4;
  int freq[4];
  max = max-1;
  int i;
  i=0;
  while (i < max+1){
    freq[i] = 0;
    i = i + 1;
  }


  histogram(n, arr, max, freq);
  print freq[0];
  print freq[1];
  print freq[2];
  print freq[3];
}

void histogram(int n, int ns[], int max, int freq[]) {
  int i;
  i = 0;
  while (i < n){
    freq[ns[i]] = freq[ns[i]] + 1;
    i = i+1;
  }
}
