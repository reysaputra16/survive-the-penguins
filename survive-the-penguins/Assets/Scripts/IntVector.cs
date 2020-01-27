[System.Serializable]
public struct IntVector {

	public int x, z;

	public IntVector (int x, int z) {
		this.x = x;
		this.z = z;
	}

	public static IntVector operator + (IntVector a, IntVector b) {
		a.x += b.x;
		a.z += b.z;
		return a;
	}
}