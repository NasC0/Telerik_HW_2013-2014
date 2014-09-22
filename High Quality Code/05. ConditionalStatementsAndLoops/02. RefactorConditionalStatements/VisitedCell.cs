bool inRange = (MIN_X <= x && x <= MAX_X) && (MIN_Y <= y && y <= MAX_Y);

if (inRange && shouldVisitCell)
{
    VisitCell();
}