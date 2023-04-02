  bool left_waiting=false;
  bool right_waiting=false;
  int left_foot=0;
  int right_foot=0;
  int threshhold= 600;
void setup() {
  Serial.begin(9600);
  bool left_waiting=false;
  bool right_waiting=false;
  int left_foot=0;
  int right_foot=0;
  int threshhold= 600;
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
 }


void loop() {
  left_foot=analogRead(A0);
  right_foot=analogRead(A1);
  if ((!left_waiting) and (left_foot<threshhold)){
    left_waiting=true;
  }   if ((!right_waiting) and (right_foot<threshhold)){
    right_waiting=true;
  }
  Serial.println(current_sensors());
  delay(30);
}

int current_sensors(){
  int total=0;
  if ( (left_foot > threshhold) and (left_waiting) ){
    total=total+1;
    left_waiting=false;
  } if ( (right_foot > threshhold) and (right_waiting)){
    total=total+2;
    right_waiting=false;
  }
  return total;
}
