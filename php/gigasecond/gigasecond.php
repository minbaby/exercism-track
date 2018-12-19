<?php
function from (\DateTime $date)
{
    $dateNew = clone $date;
    return $dateNew->add(\DateInterval::createFromDateString("1000000000 seconds"));
}