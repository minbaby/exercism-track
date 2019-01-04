class Darts {

    private double x;

    private double y;

    private static final double MAX_X = 10;

    private static final double MAX_Y = 10;

    Darts(double x, double y) {
       this.x = x;
       this.y = y;
    }

    int score() {
        if (x > MAX_X || y > MAX_Y || x < 0 || y < 0) {
            return 0;
        }

        if (x > MAX_X/2 || y > MAX_Y/2) {
            return 1;
        }

        if (x > 1 || y > 1) {
            return 5;
        }

        return 10;
    }

}
