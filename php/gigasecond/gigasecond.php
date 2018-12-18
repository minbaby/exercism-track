<?php
function from ($date)
{
    return new Gigasecond($date);
}

class Gigasecond {
    /**
     * @var \DateTime
     */
    private $date;

    public function __construct(\DateTime $date)
    {
        $this->date = $date;
    }

    public function format($format)
    {
        return $this->date->add(\DateInterval::createFromDateString("1000000000 seconds"))->format($format);
    }
}