import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;
import java.util.LinkedList;

class Main2 {
    public static void main(String[] args) {
        BufferedReader reader;
        try {
            int maxID = 0;
            List<Integer> takenSeats = new LinkedList<Integer>();

            reader = new BufferedReader(new FileReader("input.txt"));
            String line = reader.readLine();
            while (line != null) {

                int minFB = 0;
                int maxFB = 127;
                int stepsFB = 128;
                int minC = 0;
                int maxC = 7;
                int stepsC = 8;

                char[] chars = line.toCharArray();
                for (char c : chars) {

                    if (c == 'F') {
                        stepsFB = (stepsFB / 2);
                        maxFB -= stepsFB;
                    } else if (c == 'B') {
                        stepsFB = (stepsFB / 2);
                        minFB += stepsFB;
                    } else if (c == 'L') {
                        stepsC = (stepsC / 2);
                        maxC -= stepsC;
                    } else if (c == 'R') {
                        stepsC = (stepsC / 2);
                        minC += stepsC;
                    }
                }

                int result = (minFB * 8) + minC;
                takenSeats.add(result);
                if (result > maxID)
                    maxID = result;

                line = reader.readLine();
            }
            reader.close();

            int mySeat = 0;
            for (int i = 0; i < takenSeats.size(); i++) {
                int seat = i;
                if (!takenSeats.contains(seat)) {
                    mySeat = seat;
                }
            }

            System.out.println("my seat: " + (mySeat));

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}