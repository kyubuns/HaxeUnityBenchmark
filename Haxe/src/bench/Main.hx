package bench;

class Main {
	static function test1():String {
		var a = 1;
		return 'result is $a';
	}

	static function test2(n:Int):String {
		var a = 1;
		for (i in 0...n) {
			a += i;
		}
		return 'result is $a';
	}
}
