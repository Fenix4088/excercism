// See https://aka.ms/new-console-template for mor

using Exercism;

var counts = new int[]
{
    4,
    5,
    9,
    10,
    9,
    4,
    3
};

var birdCount = new BirdCount(counts);
birdCount.HasDayWithoutBirds();